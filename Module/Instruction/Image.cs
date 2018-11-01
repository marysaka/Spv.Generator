using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction SampledImage(uint ResultType, uint Image, uint Sampler)
        {
            return EmitOperationWithResulType(Op.OpSampledImage, ResultType, Image, Sampler);
        }

        public Instruction ImageSampleImplicitLod(uint ResultType, uint SampledImage, uint Coordinate)
        {
            return EmitOperationWithResulType(Op.OpImageSampleImplicitLod, ResultType, SampledImage, Coordinate);
        }

        public Instruction ImageSampleImplicitLod(uint ResultType, uint SampledImage, uint Coordinate, ImageOperandsShift ImageOperands, params uint[] Operands)
        {
            Instruction ImageSampleImplicitLod = CreateOperationWithResulType(Op.OpImageSampleImplicitLod, ResultType, SampledImage, Coordinate, (uint)ImageOperands);
            ImageSampleImplicitLod.PushOperand(Operands);

            return EmitCode(ImageSampleImplicitLod);
        }

        public Instruction ImageSampleExplicitLod(uint ResultType, uint SampledImage, uint Coordinate, uint Dref, ImageOperandsShift ImageOperands, uint Id, params uint[] Operands)
        {
            Instruction ImageSampleExplicitLod = CreateOperationWithResulType(Op.OpImageSampleExplicitLod, ResultType, SampledImage, Coordinate, Dref, (uint)ImageOperands, Id);
            ImageSampleExplicitLod.PushOperand(Operands);

            return EmitCode(ImageSampleExplicitLod);
        }

        public Instruction ImageSampleDrefImplicitLod(uint ResultType, uint SampledImage, uint Coordinate, uint Dref)
        {
            return EmitOperationWithResulType(Op.OpImageSampleDrefImplicitLod, ResultType, SampledImage, Coordinate, Dref);
        }

        public Instruction ImageSampleDrefImplicitLod(uint ResultType, uint SampledImage, uint Coordinate, uint Dref, ImageOperandsShift ImageOperands, params uint[] Operands)
        {
            Instruction ImageSampleDrefImplicitLod = CreateOperationWithResulType(Op.OpImageSampleDrefImplicitLod, ResultType, SampledImage, Coordinate, Dref, (uint)ImageOperands);
            ImageSampleDrefImplicitLod.PushOperand(Operands);

            return EmitCode(ImageSampleDrefImplicitLod);
        }

        public Instruction ImageSampleDrefExplicitLod(uint ResultType, uint SampledImage, uint Coordinate, uint Dref)
        {
            return EmitOperationWithResulType(Op.OpImageSampleDrefExplicitLod, ResultType, SampledImage, Coordinate, Dref);
        }

        public Instruction ImageSampleDrefExplicitLod(uint ResultType, uint SampledImage, uint Coordinate, uint Dref, ImageOperandsShift ImageOperands, params uint[] Operands)
        {
            Instruction ImageSampleDrefExplicitLod = CreateOperationWithResulType(Op.OpImageSampleDrefExplicitLod, ResultType, SampledImage, Coordinate, Dref, (uint)ImageOperands);
            ImageSampleDrefExplicitLod.PushOperand(Operands);

            return EmitCode(ImageSampleDrefExplicitLod);
        }

        public Instruction ImageSampleProjImplicitLod(uint ResultType, uint SampledImage, uint Coordinate)
        {
            return EmitOperationWithResulType(Op.OpImageSampleProjImplicitLod, ResultType, SampledImage, Coordinate);
        }

        public Instruction ImageSampleProjImplicitLod(uint ResultType, uint SampledImage, uint Coordinate, ImageOperandsShift ImageOperands, params uint[] Operands)
        {
            Instruction ImageSampleProjImplicitLod = CreateOperationWithResulType(Op.OpImageSampleProjImplicitLod, ResultType, SampledImage, Coordinate, (uint)ImageOperands);
            ImageSampleProjImplicitLod.PushOperand(Operands);

            return EmitCode(ImageSampleProjImplicitLod);
        }

        public Instruction ImageSampleProjExplicitLod(uint ResultType, uint SampledImage, uint Coordinate, uint Dref, ImageOperandsShift ImageOperands, uint Id, params uint[] Operands)
        {
            Instruction ImageSampleProjExplicitLod = CreateOperationWithResulType(Op.OpImageSampleProjExplicitLod, ResultType, SampledImage, Coordinate, Dref, (uint)ImageOperands, Id);
            ImageSampleProjExplicitLod.PushOperand(Operands);

            return EmitCode(ImageSampleProjExplicitLod);
        }

        public Instruction ImageSampleProjDrefImplicitLod(uint ResultType, uint SampledImage, uint Coordinate, uint Dref)
        {
            return EmitOperationWithResulType(Op.OpImageSampleProjDrefImplicitLod, ResultType, SampledImage, Coordinate, Dref);
        }

        public Instruction ImageSampleProjDrefImplicitLod(uint ResultType, uint SampledImage, uint Coordinate, uint Dref, ImageOperandsShift ImageOperands, params uint[] Operands)
        {
            Instruction ImageSampleProjDrefImplicitLod = CreateOperationWithResulType(Op.OpImageSampleProjDrefImplicitLod, ResultType, SampledImage, Coordinate, Dref, (uint)ImageOperands);
            ImageSampleProjDrefImplicitLod.PushOperand(Operands);

            return EmitCode(ImageSampleProjDrefImplicitLod);
        }

        public Instruction ImageSampleProjDrefExplicitLod(uint ResultType, uint SampledImage, uint Coordinate, uint Dref, ImageOperandsShift ImageOperands, uint Id, params uint[] Operands)
        {
            Instruction ImageSampleProjDrefExplicitLod = CreateOperationWithResulType(Op.OpImageSampleProjDrefExplicitLod, ResultType, SampledImage, Coordinate, Dref, (uint)ImageOperands, Id);
            ImageSampleProjDrefExplicitLod.PushOperand(Operands);

            return EmitCode(ImageSampleProjDrefExplicitLod);
        }

        public Instruction ImageFetch(uint ResultType, uint Image, uint Coordinate)
        {
            return EmitOperationWithResulType(Op.OpImageFetch, ResultType, Image, Coordinate);
        }

        public Instruction ImageFetch(uint ResultType, uint Image, uint Coordinate, ImageOperandsShift ImageOperands, params uint[] Operands)
        {
            Instruction ImageFetch = CreateOperationWithResulType(Op.OpImageFetch, ResultType, Image, Coordinate, (uint)ImageOperands);
            ImageFetch.PushOperand(Operands);

            return EmitCode(ImageFetch);
        }

        public Instruction ImageGather(uint ResultType, uint Image, uint Coordinate, uint Component)
        {
            return EmitOperationWithResulType(Op.OpImageGather, ResultType, Image, Coordinate, Component);
        }

        public Instruction ImageGather(uint ResultType, uint Image, uint Coordinate, uint Component, ImageOperandsShift ImageOperands, params uint[] Operands)
        {
            Instruction ImageGather = CreateOperationWithResulType(Op.OpImageGather, ResultType, Image, Coordinate, Component, (uint)ImageOperands);
            ImageGather.PushOperand(Operands);

            return EmitCode(ImageGather);
        }

        public Instruction ImageDrefGather(uint ResultType, uint Image, uint Coordinate, uint Dref)
        {
            return EmitOperationWithResulType(Op.OpImageDrefGather, ResultType, Image, Coordinate, Dref);
        }

        public Instruction ImageDrefGather(uint ResultType, uint Image, uint Coordinate, uint Dref, ImageOperandsShift ImageOperands, params uint[] Operands)
        {
            Instruction ImageDrefGather = CreateOperationWithResulType(Op.OpImageDrefGather, ResultType, Image, Coordinate, Dref, (uint)ImageOperands);
            ImageDrefGather.PushOperand(Operands);

            return EmitCode(ImageDrefGather);
        }

        public Instruction ImageRead(uint ResultType, uint Image, uint Coordinate, uint Component)
        {
            return EmitOperationWithResulType(Op.OpImageRead, ResultType, Image, Coordinate, Component);
        }

        public Instruction ImageRead(uint ResultType, uint Image, uint Coordinate, uint Component, ImageOperandsShift ImageOperands, params uint[] Operands)
        {
            Instruction ImageRead = CreateOperationWithResulType(Op.OpImageRead, ResultType, Image, Coordinate, Component, (uint)ImageOperands);
            ImageRead.PushOperand(Operands);

            return EmitCode(ImageRead);
        }

        public Instruction ImageWrite(uint Image, uint Coordinate, uint Texel)
        {
            return EmitCode(CreateInstruction(Op.OpImageWrite, Image, Coordinate, Texel));
        }

        public Instruction ImageWrite(uint Image, uint Coordinate, uint Texel, ImageOperandsShift ImageOperands, params uint[] Operands)
        {
            Instruction ImageWrite = CreateInstruction(Op.OpImageWrite, Image, Coordinate, Texel, (uint)ImageOperands);
            ImageWrite.PushOperand(Operands);

            return EmitCode(ImageWrite);
        }

        public Instruction Image(uint ResultType, uint SampledImage)
        {
            return EmitOperationWithResulType(Op.OpImage, ResultType, SampledImage);
        }

        public Instruction ImageQueryFormat(uint ResultType, uint Image)
        {
            return EmitOperationWithResulType(Op.OpImageQueryFormat, ResultType, Image);
        }

        public Instruction ImageQueryOrder(uint ResultType, uint Image)
        {
            return EmitOperationWithResulType(Op.OpImageQueryOrder, ResultType, Image);
        }


        public Instruction ImageQueryLod(uint ResultType, uint SampledImage, uint Coordinate)
        {
            return EmitOperationWithResulType(Op.OpImageQueryLod, ResultType, SampledImage, Coordinate);
        }

        public Instruction ImageQueryLevels(uint ResultType, uint Image)
        {
            return EmitOperationWithResulType(Op.OpImageQueryLevels, Image);
        }

        public Instruction ImageQuerySamples(uint ResultType, uint Image)
        {
            return EmitOperationWithResulType(Op.OpImageQuerySamples, Image);
        }


        public Instruction ImageSparseSampleImplicitLod(uint ResultType, uint SampledImage, uint Coordinate)
        {
            return EmitOperationWithResulType(Op.OpImageSparseSampleImplicitLod, ResultType, SampledImage, Coordinate);
        }

        public Instruction ImageSparseSampleImplicitLod(uint ResultType, uint SampledImage, uint Coordinate, ImageOperandsShift ImageOperands, params uint[] Operands)
        {
            Instruction ImageSparseSampleImplicitLod = CreateOperationWithResulType(Op.OpImageSparseSampleImplicitLod, ResultType, SampledImage, Coordinate, (uint)ImageOperands);
            ImageSparseSampleImplicitLod.PushOperand(Operands);

            return EmitCode(ImageSparseSampleImplicitLod);
        }

        public Instruction ImageSparseSampleExplicitLod(uint ResultType, uint SampledImage, uint Coordinate, uint Dref, ImageOperandsShift ImageOperands, uint Id, params uint[] Operands)
        {
            Instruction ImageSparseSampleExplicitLod = CreateOperationWithResulType(Op.OpImageSparseSampleExplicitLod, ResultType, SampledImage, Coordinate, Dref, (uint)ImageOperands, Id);
            ImageSparseSampleExplicitLod.PushOperand(Operands);

            return EmitCode(ImageSparseSampleExplicitLod);
        }

        public Instruction ImageSparseSampleDrefImplicitLod(uint ResultType, uint SampledImage, uint Coordinate, uint Dref)
        {
            return EmitOperationWithResulType(Op.OpImageSparseSampleDrefImplicitLod, ResultType, SampledImage, Coordinate, Dref);
        }

        public Instruction ImageSparseSampleDrefImplicitLod(uint ResultType, uint SampledImage, uint Coordinate, uint Dref, ImageOperandsShift ImageOperands, params uint[] Operands)
        {
            Instruction ImageSparseSampleDrefImplicitLod = CreateOperationWithResulType(Op.OpImageSparseSampleDrefImplicitLod, ResultType, SampledImage, Coordinate, Dref, (uint)ImageOperands);
            ImageSparseSampleDrefImplicitLod.PushOperand(Operands);

            return EmitCode(ImageSparseSampleDrefImplicitLod);
        }

        public Instruction ImageSparseSampleDrefExplicitLod(uint ResultType, uint SampledImage, uint Coordinate, uint Dref, ImageOperandsShift ImageOperands, uint Id, params uint[] Operands)
        {
            Instruction ImageSparseSampleDrefExplicitLod = CreateOperationWithResulType(Op.OpImageSparseSampleDrefExplicitLod, ResultType, SampledImage, Coordinate, Dref, (uint)ImageOperands, Id);
            ImageSparseSampleDrefExplicitLod.PushOperand(Operands);

            return EmitCode(ImageSparseSampleDrefExplicitLod);
        }

        public Instruction ImageSparseSampleProjImplicitLod(uint ResultType, uint SampledImage, uint Coordinate)
        {
            return EmitOperationWithResulType(Op.OpImageSparseSampleProjImplicitLod, ResultType, SampledImage, Coordinate);
        }

        public Instruction ImageSparseSampleProjImplicitLod(uint ResultType, uint SampledImage, uint Coordinate, ImageOperandsShift ImageOperands, params uint[] Operands)
        {
            Instruction ImageSparseSampleProjImplicitLod = CreateOperationWithResulType(Op.OpImageSparseSampleProjImplicitLod, ResultType, SampledImage, Coordinate, (uint)ImageOperands);
            ImageSparseSampleProjImplicitLod.PushOperand(Operands);

            return EmitCode(ImageSparseSampleProjImplicitLod);
        }

        public Instruction ImageSparseSampleProjExplicitLod(uint ResultType, uint SampledImage, uint Coordinate, uint Dref, ImageOperandsShift ImageOperands, uint Id, params uint[] Operands)
        {
            Instruction ImageSparseSampleProjExplicitLod = CreateOperationWithResulType(Op.OpImageSparseSampleProjExplicitLod, ResultType, SampledImage, Coordinate, Dref, (uint)ImageOperands, Id);
            ImageSparseSampleProjExplicitLod.PushOperand(Operands);

            return EmitCode(ImageSparseSampleProjExplicitLod);
        }

        public Instruction ImageSparseSampleProjDrefImplicitLod(uint ResultType, uint SampledImage, uint Coordinate, uint Dref)
        {
            return EmitOperationWithResulType(Op.OpImageSparseSampleProjDrefImplicitLod, ResultType, SampledImage, Coordinate, Dref);
        }

        public Instruction ImageSparseSampleProjDrefImplicitLod(uint ResultType, uint SampledImage, uint Coordinate, uint Dref, ImageOperandsShift ImageOperands, params uint[] Operands)
        {
            Instruction ImageSparseSampleProjDrefImplicitLod = CreateOperationWithResulType(Op.OpImageSparseSampleProjDrefImplicitLod, ResultType, SampledImage, Coordinate, Dref, (uint)ImageOperands);
            ImageSparseSampleProjDrefImplicitLod.PushOperand(Operands);

            return EmitCode(ImageSparseSampleProjDrefImplicitLod);
        }

        public Instruction ImageSparseSampleProjDrefExplicitLod(uint ResultType, uint SampledImage, uint Coordinate, uint Dref, ImageOperandsShift ImageOperands, uint Id, params uint[] Operands)
        {
            Instruction ImageSparseSampleProjDrefExplicitLod = CreateOperationWithResulType(Op.OpImageSparseSampleProjDrefExplicitLod, ResultType, SampledImage, Coordinate, Dref, (uint)ImageOperands, Id);
            ImageSparseSampleProjDrefExplicitLod.PushOperand(Operands);

            return EmitCode(ImageSparseSampleProjDrefExplicitLod);
        }

        public Instruction ImageSparseFetch(uint ResultType, uint Image, uint Coordinate)
        {
            return EmitOperationWithResulType(Op.OpImageSparseFetch, ResultType, Image, Coordinate);
        }

        public Instruction ImageSparseFetch(uint ResultType, uint Image, uint Coordinate, ImageOperandsShift ImageOperands, params uint[] Operands)
        {
            Instruction ImageSparseFetch = CreateOperationWithResulType(Op.OpImageSparseFetch, ResultType, Image, Coordinate, (uint)ImageOperands);
            ImageSparseFetch.PushOperand(Operands);

            return EmitCode(ImageSparseFetch);
        }

        public Instruction ImageSparseGather(uint ResultType, uint Image, uint Coordinate, uint Component)
        {
            return EmitOperationWithResulType(Op.OpImageSparseGather, ResultType, Image, Coordinate, Component);
        }

        public Instruction ImageSparseGather(uint ResultType, uint Image, uint Coordinate, uint Component, ImageOperandsShift ImageOperands, params uint[] Operands)
        {
            Instruction ImageSparseGather = CreateOperationWithResulType(Op.OpImageSparseGather, ResultType, Image, Coordinate, Component, (uint)ImageOperands);
            ImageSparseGather.PushOperand(Operands);

            return EmitCode(ImageSparseGather);
        }

        public Instruction ImageSparseFetch(uint ResultType, uint Image, uint Coordinate, uint Dref)
        {
            return EmitOperationWithResulType(Op.OpImageSparseFetch, ResultType, Image, Coordinate, Dref);
        }

        public Instruction ImageSparseFetch(uint ResultType, uint Image, uint Coordinate, uint Dref, ImageOperandsShift ImageOperands, params uint[] Operands)
        {
            Instruction ImageSparseFetch = CreateOperationWithResulType(Op.OpImageSparseFetch, ResultType, Image, Coordinate, (uint)ImageOperands);
            ImageSparseFetch.PushOperand(Operands);

            return EmitCode(ImageSparseFetch);
        }

        public Instruction ImageSparseDrefGather(uint ResultType, uint Image, uint Coordinate, uint Dref)
        {
            return EmitOperationWithResulType(Op.OpImageSparseDrefGather, ResultType, Image, Coordinate, Dref);
        }

        public Instruction ImageSparseDrefGather(uint ResultType, uint Image, uint Coordinate, uint Dref, ImageOperandsShift ImageOperands, params uint[] Operands)
        {
            Instruction ImageSparseDrefGather = CreateOperationWithResulType(Op.OpImageSparseDrefGather, ResultType, Image, Coordinate, Dref, (uint)ImageOperands);
            ImageSparseDrefGather.PushOperand(Operands);

            return EmitCode(ImageSparseDrefGather);
        }

        public Instruction ImageSparseTexelsResident(uint ResultType, uint ResidentCode)
        {
            return EmitOperationWithResulType(Op.OpImageSparseTexelsResident, ResultType, ResidentCode);
        }

        public Instruction ImageSparseRead(uint ResultType, uint Image, uint Coordinate)
        {
            return EmitOperationWithResulType(Op.OpImageSparseRead, ResultType, Image, Coordinate);
        }

        public Instruction ImageSparseRead(uint ResultType, uint Image, uint Coordinate, ImageOperandsShift ImageOperands, params uint[] Operands)
        {
            Instruction ImageSparseRead = CreateOperationWithResulType(Op.OpImageSparseRead, ResultType, Image, Coordinate, (uint)ImageOperands);
            ImageSparseRead.PushOperand(Operands);

            return EmitCode(ImageSparseRead);
        }
    }
}
