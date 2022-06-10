#!/usr/bin/env python3
# -*- coding: utf-8 -*-

import datetime
import json
import sys
import os

class CodeStream:
    def __init__(self):
        self.code = ""
        self.spaces = 0
        
    def get(self): return self.code
    
    def indent(self): self.spaces += 4
    def unindent(self): self.spaces -= 4
    
    def write(self, text):
        self.code += text
        
    def begin_line(self):
        self.write(" " * self.spaces)
        
    def write_line(self, line=""):
        self.begin_line()
        self.write(line + "\n")

class MethodArgument:
    def __init__(self, name, real_type, c_sharp_type, optional, variable, behind_optional_argument = None):
        self.name = name
        self.real_type = real_type
        self.c_sharp_type = c_sharp_type
        self.optional = optional
        self.variable = variable
        self.behind_optional_argument = behind_optional_argument
    
    def get_prototype_name(self):
        if self.optional:
            return '{0} {1} = {2}'.format(self.c_sharp_type, self.name, self.get_default_value())
        if self.variable:
            return 'params {0}[] {1}'.format(self.c_sharp_type, self.name)
        return '{0} {1}'.format(self.c_sharp_type, self.name)

    def get_default_value(self):
        default_value = 'null'

        if self.c_sharp_type == 'bool':
            default_value = 'false'
        # Assume enum if it's not an Instruction,
        # We use some invalid value in this case to detect that the user hasn't send anything
        # TODO: improve this
        elif self.c_sharp_type != 'Instruction' and self.c_sharp_type != 'string':
            default_value = '({0})int.MaxValue'.format(self.c_sharp_type)
            
        return default_value

    def get_as_operand(self):
        enum_defined = [
            'FPRoundingMode'
        ]

        kind = self.c_sharp_type

        if kind in enum_defined:
            return 'LiteralInteger.CreateForEnum({0})'.format(self.name)

        return self.name

    def generate_add_operant_operation(self, stream):
        # skip result type as it's send in the constructor
        if self.name == 'resultType' or self.name == 'forceIdAllocation':
            return

        if self.optional:
            optional_check = self
        elif self.behind_optional_argument:
            optional_check = self.behind_optional_argument
        else:
            optional_check = None

        if optional_check != None:
            stream.write_line("if ({0} != {1})".format(optional_check.name, optional_check.get_default_value()))
            stream.write_line("{")
            stream.indent()
        stream.write_line('result.AddOperand({0});'.format(self.name))
        if optional_check != None:
            stream.unindent()
            stream.write_line("}")

class MethodInfo:
    def fix_possible_argument_conflicts(self, name):
        conflict_count = -1
        
        for argument in self.arguments:
            if argument.name == name:
                conflict_count += 1
        
        if conflict_count > 0:
            index = 0
            for argument in self.arguments:
                if argument.name == name:
                    argument.name = '{0}{1}'.format(argument.name, index)
                    index += 1

    def __init__(self, instruction, extinst_info):
        self.extinst_info = extinst_info
        self.bound_increment_needed = False
        self.result_type_index = -1
        self.opcode = instruction['opcode']
        self.arguments = []

        if extinst_info != None:
            self.cl = 'ExtInst'
            self.name = extinst_info['function_prefix'] + instruction['opname'][:1].upper() + instruction['opname'][1:]
            self.arguments.append(MethodArgument("resultType", 'IdRef', 'Instruction', False, False))
        else:
            self.name = instruction['opname'][2:]
            self.cl = instruction['class']
        i = 0

        if 'operands' in instruction:
            for operand in instruction['operands']:
                if operand['kind'] != 'IdResult':
                    if operand['kind'] == 'IdResultType':
                        self.result_type_index = i

                    variable =  'quantifier' in operand and operand['quantifier'] == '*'
                    optional =  'quantifier' in operand and operand['quantifier'] == '?'

                    # The core grammar doesn't contains the optional <id> when ImageOperands is defined on image instructions, add them manually.
                    if operand['kind'] == "ImageOperands" and self.cl == "Image":
                        image_operands = MethodArgument(get_argument_name(operand, i), operand['kind'], get_type_by_operand(operand), False, False)

                        if optional:
                            # TODO: improve this as this generate two if..
                            image_operands.behind_optional_argument = image_operands

                        self.arguments.append(image_operands)
                        self.arguments.append(MethodArgument("imageOperandIds", 'IdRef', 'Instruction', False, True, image_operands))
                    else:
                        self.arguments.append(MethodArgument(get_argument_name(operand, i), operand['kind'], get_type_by_operand(operand), optional, variable))
                    
                    # Decoration and ExecutionMode are special as they carry variable operands
                    if operand['kind'] in ['Decoration', 'ExecutionMode']:
                        self.arguments.append(MethodArgument('parameters', 'Operands', 'Operand', False, True))

                    i += 1
                else:
                    self.bound_increment_needed = True

        if self.cl == 'Type-Declaration':
            force_id_allocation_arg = MethodArgument('forceIdAllocation', 'bool', 'bool', not self.name in ['TypeFunction', 'TypeStruct'], False)
            if self.name in ['TypeFunction', 'TypeStruct']:
                self.arguments.insert(len(self.arguments) - 1, force_id_allocation_arg)
            else:
                self.arguments.append(force_id_allocation_arg)

        for argument in self.arguments:
            self.fix_possible_argument_conflicts(argument.name)


def get_instructions_by_class(spec_data, cl):
    result = []
    for instruction in spec_data['instructions']:
        if instruction['class'] == cl:
            result.append(instruction)
    return result

def get_instruction_by_name(spec_data, opname):
    for instruction in spec_data['instructions']:
        if instruction['opname'] == opname:
            return instruction
    return None

def get_argument_name(operand, position):
    if operand['kind'] == 'IdResultType':
        return 'resultType'
    
    if 'name' in operand and not '\n' in operand['name'] and not '~' in operand['name'] and not ',' in operand['name'] and operand['name'].isascii():
        name = operand['name'].replace('\'', '').replace(' ', '').replace('.', '')

        name = name[0].lower() + name[1:]

        # replace reserved words
        if name == 'object':
            return 'obj'
        if name == 'string':
            return 'str'
        elif name == 'base':
            return 'baseObj'
        elif name == 'default':
            return 'defaultObj'
        elif name == 'event':
            return 'eventObj'
        elif name == 'result':
            return 'resultObj'

        return name

    # the name wasn't derived from the description, try to match some common types that are allowed.
    namemapping = [
        'Dim',
        'ImageFormat',
        'AccessQualifier',
        'AccessQualifier',
        'StorageClass',
        'SamplerAddressingMode',
        'SamplerFilterMode',
        'FunctionControl',
        'ImageOperands',
        'LoopControl',
        'SelectionControl',
        'MemoryAccess',
        'Decoration',
        'SourceLanguage'
    ]

    if operand['kind'] in namemapping:
        return operand['kind'][0].lower() + operand['kind'][1:]

    # Dref case
    if 'name' in operand and operand['name'] == '\'D~ref~\'':
        return 'dRef'

    # this case is a pain to handle, let's just give up in this case
    if operand['kind'] in ['IdRef', 'PairIdRefIdRef'] and 'quantifier' in operand and operand['quantifier'] == '*':
        return 'parameters'
    

    print('// Unmanaged argument name: {0}'.format(operand))


    return 'arg{0}'.format(position)

def get_type_by_operand(operand):
    enum_masks = ['MemoryAccess', 'ImageOperands', 'LoopControl', 'SelectionControl', 'FunctionControl']

    typemapping = {
        'LiteralString': 'string',
        'IdRef': 'Instruction',
        'IdResultType': 'Instruction',
        'IdScope': 'Instruction',
        'IdMemorySemantics': 'Instruction',
        'PairIdRefIdRef': 'Instruction',
        'LiteralContextDependentNumber': 'LiteralInteger',
        'LiteralSpecConstantOpInteger': 'LiteralInteger',
        'PairLiteralIntegerIdRef': 'Operand',
        'PairIdRefLiteralInteger': 'Operand',
        'LiteralExtInstInteger': 'LiteralInteger',
    }

    kind = operand['kind']

    result = kind

    if kind in typemapping:
        result = typemapping[kind]
    if kind in enum_masks:
        result = kind + 'Mask'

    #if 'quantifier' in operand and operand['quantifier'] == '*':
    #    result = 'params {0}[]'.format(result)


    return result

def generate_method_for_instruction(stream, instruction, extinst_info):
    method_info = MethodInfo(instruction, extinst_info)

    # Ignore OpenCL printf as it cannot generate for now.
    if method_info.name == 'OpenClPrintf':
        return

    stream.indent()
    generate_method_prototye(stream, method_info)
    generate_method_definition(stream, method_info)
    stream.unindent()

def generate_method_definition(stream, method_info):
    stream.write_line('{')
    stream.indent()

    if method_info.extinst_info != None:
        arguments = []

        for argument in method_info.arguments[1:]:
            arguments.append(argument.get_as_operand())
        
        arguments = ', '.join(arguments)


        stream.write_line('return ExtInst(resultType, AddExtInstImport("{0}"), {1}, {2});'.format(method_info.extinst_info['name'], method_info.opcode, arguments))
    elif method_info.bound_increment_needed:
        if method_info.result_type_index != -1:
            argument = method_info.arguments[method_info.result_type_index]
            if method_info.cl == 'Constant-Creation' and method_info.name.startswith('Constant'):
                stream.write_line('Instruction result = new Instruction(Op.Op{0}, Instruction.InvalidId, {1});'.format(method_info.name, argument.name))
            else:
                stream.write_line('Instruction result = new Instruction(Op.Op{0}, GetNewId(), {1});'.format(method_info.name, argument.name))
        else:
            # Optimization: here we explictly don't set the id because it will be set in AddTypeDeclaration/AddLabel.
            # In the end this permit to not reserve id that will be discared.
            if method_info.cl == 'Type-Declaration' or method_info.name == 'Label':
                stream.write_line('Instruction result = new Instruction(Op.Op{0});'.format(method_info.name))
            else:
                stream.write_line('Instruction result = new Instruction(Op.Op{0}, GetNewId());'.format(method_info.name))
    else:
        if method_info.result_type_index != -1:
            raise "TODO"
        stream.write_line('Instruction result = new Instruction(Op.Op{0});'.format(method_info.name))

    if method_info.extinst_info == None:
        stream.write_line()

        for argument in method_info.arguments:
            argument.generate_add_operant_operation(stream)

        if method_info.cl == 'Type-Declaration':
            stream.write_line('AddTypeDeclaration(result, forceIdAllocation);')
            stream.write_line()
        elif method_info.cl == 'Debug':
            stream.write_line('AddDebug(result);')
            stream.write_line()        
        elif method_info.cl == 'Annotation':
            stream.write_line('AddAnnotation(result);')
            stream.write_line()
        elif method_info.cl == 'Constant-Creation' and method_info.name.startswith('Constant'):
            stream.write_line('AddConstant(result);')
            stream.write_line()
        elif not method_info.name == 'Variable' and not method_info.name == 'Label':
            stream.write_line('AddToFunctionDefinitions(result);')
            stream.write_line()
        stream.write_line('return result;')

    stream.unindent()
    stream.write_line('}')
    stream.write_line()

def generate_method_prototye(stream, method_info):
    stream.begin_line()
    stream.write('public Instruction {0}('.format(method_info.name))

    arguments = []

    i = 0

    for argument in method_info.arguments:
        arguments.append(argument.get_prototype_name())
        i += 1

    stream.write(', '.join(arguments))
    stream.write(')\n')

def generate_methods_for_extinst(stream, spec_data, extinst_info):
    for instruction in spec_data['instructions']:
        generate_method_for_instruction(stream, instruction, extinst_info)

def generate_methods_by_class(stream, spec_data, cl):
    opname_blacklist = [
        'OpExtInstImport',
        'OpExtension',
    ]

    stream.indent()
    stream.write_line('// {0}'.format(cl))
    stream.write_line()
    stream.unindent()
    for instruction in get_instructions_by_class(spec_data, cl):
        opname = instruction['opname']

        # Skip blacklisted op names (already defined with custom apis ect)
        if opname in opname_blacklist:
            continue

        generate_method_for_instruction(stream, instruction, None)

def main():
    if len(sys.argv) < 3:
        print("usage: %s grammar.json Target.cs" % (sys.argv[0]))
        exit(1)

    # spec file path is the core file
    spec_filepath = sys.argv[1]
    result_filepath = sys.argv[2]

    # Get extension files, names and prefixes
    extinst_naming_mapping = {
        'extinst.glsl.std.450.grammar.json': { 'name': 'GLSL.std.450', 'function_prefix': 'Glsl'},
        'extinst.opencl.std.100.grammar.json': { 'name': 'OpenCL.std', 'function_prefix': 'OpenCl'},
    }

    # gets the path of the directory for the other files
    spec_filename = os.path.basename(spec_filepath)
    
    extinst_info = None

    if spec_filename in extinst_naming_mapping:
        extinst_info = extinst_naming_mapping[spec_filename]

    with open(spec_filepath, "r") as f:
        spec_data = json.loads(f.read())

    stream = CodeStream()

    stream.write_line("// AUTOGENERATED: DO NOT EDIT")
    stream.write_line("// Last update date: {0}".format(datetime.datetime.now()))

    stream.write_line("#region Grammar License")
    for copyright_line in spec_data['copyright']:
        stream.write_line('// {0}'.format(copyright_line))
    
    stream.write_line("#endregion")
    stream.write_line()


    stream.write_line('using static Spv.Specification;')
    stream.write_line()
    stream.write_line('namespace Spv.Generator')
    stream.write_line('{')
    stream.indent()
    stream.write_line('public partial class Module')
    stream.write_line('{')


    if extinst_info != None:
        generate_methods_for_extinst(stream, spec_data, extinst_info)
    else:
        generate_methods_by_class(stream, spec_data, 'Miscellaneous')
        generate_methods_by_class(stream, spec_data, 'Debug')
        generate_methods_by_class(stream, spec_data, 'Annotation')
        generate_methods_by_class(stream, spec_data, 'Type-Declaration')
        generate_methods_by_class(stream, spec_data, 'Constant-Creation')
        generate_methods_by_class(stream, spec_data, 'Memory')
        generate_methods_by_class(stream, spec_data, 'Function')
        generate_methods_by_class(stream, spec_data, 'Image')
        generate_methods_by_class(stream, spec_data, 'Conversion')
        generate_methods_by_class(stream, spec_data, 'Composite')
        generate_methods_by_class(stream, spec_data, 'Arithmetic')
        generate_methods_by_class(stream, spec_data, 'Bit')
        generate_methods_by_class(stream, spec_data, 'Relational_and_Logical')
        generate_methods_by_class(stream, spec_data, 'Derivative')
        generate_methods_by_class(stream, spec_data, 'Control-Flow')
        generate_methods_by_class(stream, spec_data, 'Atomic')
        generate_methods_by_class(stream, spec_data, 'Primitive')
        generate_methods_by_class(stream, spec_data, 'Barrier')
        generate_methods_by_class(stream, spec_data, 'Group')
        generate_methods_by_class(stream, spec_data, 'Device-Side_Enqueue')
        generate_methods_by_class(stream, spec_data, 'Pipe')
        generate_methods_by_class(stream, spec_data, 'Non-Uniform')
        generate_methods_by_class(stream, spec_data, 'Reserved')

    stream.write_line('}')
    stream.unindent()
    stream.write_line('}')

    with open(result_filepath, "w+") as result_file:
        result_file.write(stream.get())

    return


if __name__ == '__main__':
    main()
