using System.Text.Json;

namespace SpvSourceGenerator;

public class MethodInfo {

    public JsonDocument extinst_info;
    public bool boundIncrementNeeded;
    public int result_type_index;
    public string opcode;
    public List<string> arguments;
    void FixPossibleArgumentConflicts(string name)
    {
        conflict_count = -1
        
        foreach(var argument in this.arguments):
            if argument.name == name:
                conflict_count += 1
        
        if conflict_count > 0:
            index = 0
            for argument in self.arguments:
                if argument.name == name:
                    argument.name = '{0}{1}'.format(argument.name, index)
                    index += 1
    }
    public MethodInfo(JsonElement instruction, JsonDocument extinst_info)
    {
        this.extinstInfo = extinst_info;
        this.boundIncrementNeeded = false;
        this.result_type_index = -1;
        this.opcode = instruction.GetProperty("opcode");
        this.arguments = new List<string>();

        if(extinstInfo != null)
            this.cl = "ExtInst"
            this.name = extinst_info['function_prefix'] + instruction['opname'][:1].upper() + instruction['opname'][1:]
            this.arguments.append(MethodArgument("resultType", 'IdRef', 'Instruction', False, False))
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