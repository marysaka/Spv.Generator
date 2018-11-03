using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction SampledImage(Instruction ResultType, Instruction Image, Instruction Sampler)
        {
            return EmitOperationWithResulType(Op.OpSampledImage, ResultType, Image.ResultTypeId, Sampler.ResultTypeId);
        }

        public Instruction ImageSampleImplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate)
        {
            return EmitOperationWithResulType(Op.OpImageSampleImplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId);
        }

        public Instruction ImageSampleImplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, ImageOperandsShift ImageOperands, params Instruction[] Operands)
        {
            Instruction ImageSampleImplicitLod = CreateOperationWithResulType(Op.OpImageSampleImplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, (uint)ImageOperands);
            ImageSampleImplicitLod.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSampleImplicitLod);
        }

        public Instruction ImageSampleExplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, Instruction Dref, ImageOperandsShift ImageOperands, Instruction Id, params Instruction[] Operands)
        {
            Instruction ImageSampleExplicitLod = CreateOperationWithResulType(Op.OpImageSampleExplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId, (uint)ImageOperands, Id.ResultTypeId);
            ImageSampleExplicitLod.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSampleExplicitLod);
        }

        public Instruction ImageSampleDrefImplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, Instruction Dref)
        {
            return EmitOperationWithResulType(Op.OpImageSampleDrefImplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId);
        }

        public Instruction ImageSampleDrefImplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, Instruction Dref, ImageOperandsShift ImageOperands, params Instruction[] Operands)
        {
            Instruction ImageSampleDrefImplicitLod = CreateOperationWithResulType(Op.OpImageSampleDrefImplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId, (uint)ImageOperands);
            ImageSampleDrefImplicitLod.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSampleDrefImplicitLod);
        }

        public Instruction ImageSampleDrefExplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, Instruction Dref)
        {
            return EmitOperationWithResulType(Op.OpImageSampleDrefExplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId);
        }

        public Instruction ImageSampleDrefExplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, Instruction Dref, ImageOperandsShift ImageOperands, params Instruction[] Operands)
        {
            Instruction ImageSampleDrefExplicitLod = CreateOperationWithResulType(Op.OpImageSampleDrefExplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId, (uint)ImageOperands);
            ImageSampleDrefExplicitLod.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSampleDrefExplicitLod);
        }

        public Instruction ImageSampleProjImplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate)
        {
            return EmitOperationWithResulType(Op.OpImageSampleProjImplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId);
        }

        public Instruction ImageSampleProjImplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, ImageOperandsShift ImageOperands, params Instruction[] Operands)
        {
            Instruction ImageSampleProjImplicitLod = CreateOperationWithResulType(Op.OpImageSampleProjImplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, (uint)ImageOperands);
            ImageSampleProjImplicitLod.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSampleProjImplicitLod);
        }

        public Instruction ImageSampleProjExplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, Instruction Dref, ImageOperandsShift ImageOperands, Instruction Id, params Instruction[] Operands)
        {
            Instruction ImageSampleProjExplicitLod = CreateOperationWithResulType(Op.OpImageSampleProjExplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId, (uint)ImageOperands, Id.ResultTypeId);
            ImageSampleProjExplicitLod.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSampleProjExplicitLod);
        }

        public Instruction ImageSampleProjDrefImplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, Instruction Dref)
        {
            return EmitOperationWithResulType(Op.OpImageSampleProjDrefImplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId);
        }

        public Instruction ImageSampleProjDrefImplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, Instruction Dref, ImageOperandsShift ImageOperands, params Instruction[] Operands)
        {
            Instruction ImageSampleProjDrefImplicitLod = CreateOperationWithResulType(Op.OpImageSampleProjDrefImplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId, (uint)ImageOperands);
            ImageSampleProjDrefImplicitLod.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSampleProjDrefImplicitLod);
        }

        public Instruction ImageSampleProjDrefExplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, Instruction Dref, ImageOperandsShift ImageOperands, Instruction Id, params Instruction[] Operands)
        {
            Instruction ImageSampleProjDrefExplicitLod = CreateOperationWithResulType(Op.OpImageSampleProjDrefExplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId, (uint)ImageOperands, Id.ResultTypeId);
            ImageSampleProjDrefExplicitLod.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSampleProjDrefExplicitLod);
        }

        public Instruction ImageFetch(Instruction ResultType, Instruction Image, Instruction Coordinate)
        {
            return EmitOperationWithResulType(Op.OpImageFetch, ResultType, Image.ResultTypeId, Coordinate.ResultTypeId);
        }

        public Instruction ImageFetch(Instruction ResultType, Instruction Image, Instruction Coordinate, ImageOperandsShift ImageOperands, params Instruction[] Operands)
        {
            Instruction ImageFetch = CreateOperationWithResulType(Op.OpImageFetch, ResultType, Image.ResultTypeId, Coordinate.ResultTypeId, (uint)ImageOperands);
            ImageFetch.PushOperandResultTypeId(Operands);

            return EmitCode(ImageFetch);
        }

        public Instruction ImageGather(Instruction ResultType, Instruction Image, Instruction Coordinate, Instruction Component)
        {
            return EmitOperationWithResulType(Op.OpImageGather, ResultType, Image.ResultTypeId, Coordinate.ResultTypeId, Component.ResultTypeId);
        }

        public Instruction ImageGather(Instruction ResultType, Instruction Image, Instruction Coordinate, Instruction Component, ImageOperandsShift ImageOperands, params Instruction[] Operands)
        {
            Instruction ImageGather = CreateOperationWithResulType(Op.OpImageGather, ResultType, Image.ResultTypeId, Coordinate.ResultTypeId, Component.ResultTypeId, (uint)ImageOperands);
            ImageGather.PushOperandResultTypeId(Operands);

            return EmitCode(ImageGather);
        }

        public Instruction ImageDrefGather(Instruction ResultType, Instruction Image, Instruction Coordinate, Instruction Dref)
        {
            return EmitOperationWithResulType(Op.OpImageDrefGather, ResultType, Image.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId);
        }

        public Instruction ImageDrefGather(Instruction ResultType, Instruction Image, Instruction Coordinate, Instruction Dref, ImageOperandsShift ImageOperands, params Instruction[] Operands)
        {
            Instruction ImageDrefGather = CreateOperationWithResulType(Op.OpImageDrefGather, ResultType, Image.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId, (uint)ImageOperands);
            ImageDrefGather.PushOperandResultTypeId(Operands);

            return EmitCode(ImageDrefGather);
        }

        public Instruction ImageRead(Instruction ResultType, Instruction Image, Instruction Coordinate, Instruction Component)
        {
            return EmitOperationWithResulType(Op.OpImageRead, ResultType, Image.ResultTypeId, Coordinate.ResultTypeId, Component.ResultTypeId);
        }

        public Instruction ImageRead(Instruction ResultType, Instruction Image, Instruction Coordinate, Instruction Component, ImageOperandsShift ImageOperands, params Instruction[] Operands)
        {
            Instruction ImageRead = CreateOperationWithResulType(Op.OpImageRead, ResultType, Image.ResultTypeId, Coordinate.ResultTypeId, Component.ResultTypeId, (uint)ImageOperands);
            ImageRead.PushOperandResultTypeId(Operands);

            return EmitCode(ImageRead);
        }

        public Instruction ImageWrite(Instruction Image, Instruction Coordinate, Instruction Texel)
        {
            return EmitCode(CreateInstruction(Op.OpImageWrite, Image.ResultTypeId, Coordinate.ResultTypeId, Texel.ResultTypeId));
        }

        public Instruction ImageWrite(Instruction Image, Instruction Coordinate, Instruction Texel, ImageOperandsShift ImageOperands, params Instruction[] Operands)
        {
            Instruction ImageWrite = CreateInstruction(Op.OpImageWrite, Image.ResultTypeId, Coordinate.ResultTypeId, Texel.ResultTypeId, (uint)ImageOperands);
            ImageWrite.PushOperandResultTypeId(Operands);

            return EmitCode(ImageWrite);
        }

        public Instruction Image(Instruction ResultType, Instruction SampledImage)
        {
            return EmitOperationWithResulType(Op.OpImage, ResultType, SampledImage.ResultTypeId);
        }

        public Instruction ImageQueryFormat(Instruction ResultType, Instruction Image)
        {
            return EmitOperationWithResulType(Op.OpImageQueryFormat, ResultType, Image.ResultTypeId);
        }

        public Instruction ImageQueryOrder(Instruction ResultType, Instruction Image)
        {
            return EmitOperationWithResulType(Op.OpImageQueryOrder, ResultType, Image.ResultTypeId);
        }


        public Instruction ImageQueryLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate)
        {
            return EmitOperationWithResulType(Op.OpImageQueryLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId);
        }

        public Instruction ImageQueryLevels(Instruction ResultType, Instruction Image)
        {
            return EmitOperationWithResulType(Op.OpImageQueryLevels, ResultType, Image.ResultTypeId);
        }

        public Instruction ImageQuerySamples(Instruction ResultType, Instruction Image)
        {
            return EmitOperationWithResulType(Op.OpImageQuerySamples, ResultType, Image.ResultTypeId);
        }


        public Instruction ImageSparseSampleImplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate)
        {
            return EmitOperationWithResulType(Op.OpImageSparseSampleImplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId);
        }

        public Instruction ImageSparseSampleImplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, ImageOperandsShift ImageOperands, params Instruction[] Operands)
        {
            Instruction ImageSparseSampleImplicitLod = CreateOperationWithResulType(Op.OpImageSparseSampleImplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, (uint)ImageOperands);
            ImageSparseSampleImplicitLod.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSparseSampleImplicitLod);
        }

        public Instruction ImageSparseSampleExplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, Instruction Dref, ImageOperandsShift ImageOperands, Instruction Id, params Instruction[] Operands)
        {
            Instruction ImageSparseSampleExplicitLod = CreateOperationWithResulType(Op.OpImageSparseSampleExplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId, (uint)ImageOperands, Id.ResultTypeId);
            ImageSparseSampleExplicitLod.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSparseSampleExplicitLod);
        }

        public Instruction ImageSparseSampleDrefImplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, Instruction Dref)
        {
            return EmitOperationWithResulType(Op.OpImageSparseSampleDrefImplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId);
        }

        public Instruction ImageSparseSampleDrefImplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, Instruction Dref, ImageOperandsShift ImageOperands, params Instruction[] Operands)
        {
            Instruction ImageSparseSampleDrefImplicitLod = CreateOperationWithResulType(Op.OpImageSparseSampleDrefImplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId, (uint)ImageOperands);
            ImageSparseSampleDrefImplicitLod.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSparseSampleDrefImplicitLod);
        }

        public Instruction ImageSparseSampleDrefExplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, Instruction Dref, ImageOperandsShift ImageOperands, Instruction Id, params Instruction[] Operands)
        {
            Instruction ImageSparseSampleDrefExplicitLod = CreateOperationWithResulType(Op.OpImageSparseSampleDrefExplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId, (uint)ImageOperands, Id.ResultTypeId);
            ImageSparseSampleDrefExplicitLod.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSparseSampleDrefExplicitLod);
        }

        public Instruction ImageSparseSampleProjImplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate)
        {
            return EmitOperationWithResulType(Op.OpImageSparseSampleProjImplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId);
        }

        public Instruction ImageSparseSampleProjImplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, ImageOperandsShift ImageOperands, params Instruction[] Operands)
        {
            Instruction ImageSparseSampleProjImplicitLod = CreateOperationWithResulType(Op.OpImageSparseSampleProjImplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, (uint)ImageOperands);
            ImageSparseSampleProjImplicitLod.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSparseSampleProjImplicitLod);
        }

        public Instruction ImageSparseSampleProjExplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, Instruction Dref, ImageOperandsShift ImageOperands, Instruction Id, params Instruction[] Operands)
        {
            Instruction ImageSparseSampleProjExplicitLod = CreateOperationWithResulType(Op.OpImageSparseSampleProjExplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId, (uint)ImageOperands, Id.ResultTypeId);
            ImageSparseSampleProjExplicitLod.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSparseSampleProjExplicitLod);
        }

        public Instruction ImageSparseSampleProjDrefImplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, Instruction Dref)
        {
            return EmitOperationWithResulType(Op.OpImageSparseSampleProjDrefImplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId);
        }

        public Instruction ImageSparseSampleProjDrefImplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, Instruction Dref, ImageOperandsShift ImageOperands, params Instruction[] Operands)
        {
            Instruction ImageSparseSampleProjDrefImplicitLod = CreateOperationWithResulType(Op.OpImageSparseSampleProjDrefImplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId, (uint)ImageOperands);
            ImageSparseSampleProjDrefImplicitLod.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSparseSampleProjDrefImplicitLod);
        }

        public Instruction ImageSparseSampleProjDrefExplicitLod(Instruction ResultType, Instruction SampledImage, Instruction Coordinate, Instruction Dref, ImageOperandsShift ImageOperands, Instruction Id, params Instruction[] Operands)
        {
            Instruction ImageSparseSampleProjDrefExplicitLod = CreateOperationWithResulType(Op.OpImageSparseSampleProjDrefExplicitLod, ResultType, SampledImage.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId, (uint)ImageOperands, Id.ResultTypeId);
            ImageSparseSampleProjDrefExplicitLod.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSparseSampleProjDrefExplicitLod);
        }

        public Instruction ImageSparseFetch(Instruction ResultType, Instruction Image, Instruction Coordinate)
        {
            return EmitOperationWithResulType(Op.OpImageSparseFetch, ResultType, Image.ResultTypeId, Coordinate.ResultTypeId);
        }

        public Instruction ImageSparseFetch(Instruction ResultType, Instruction Image, Instruction Coordinate, ImageOperandsShift ImageOperands, params Instruction[] Operands)
        {
            Instruction ImageSparseFetch = CreateOperationWithResulType(Op.OpImageSparseFetch, ResultType, Image.ResultTypeId, Coordinate.ResultTypeId, (uint)ImageOperands);
            ImageSparseFetch.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSparseFetch);
        }

        public Instruction ImageSparseGather(Instruction ResultType, Instruction Image, Instruction Coordinate, Instruction Component)
        {
            return EmitOperationWithResulType(Op.OpImageSparseGather, ResultType, Image.ResultTypeId, Coordinate.ResultTypeId, Component.ResultTypeId);
        }

        public Instruction ImageSparseGather(Instruction ResultType, Instruction Image, Instruction Coordinate, Instruction Component, ImageOperandsShift ImageOperands, params Instruction[] Operands)
        {
            Instruction ImageSparseGather = CreateOperationWithResulType(Op.OpImageSparseGather, ResultType, Image.ResultTypeId, Coordinate.ResultTypeId, Component.ResultTypeId, (uint)ImageOperands);
            ImageSparseGather.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSparseGather);
        }

        public Instruction ImageSparseFetch(Instruction ResultType, Instruction Image, Instruction Coordinate, Instruction Dref)
        {
            return EmitOperationWithResulType(Op.OpImageSparseFetch, ResultType, Image.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId);
        }

        public Instruction ImageSparseFetch(Instruction ResultType, Instruction Image, Instruction Coordinate, Instruction Dref, ImageOperandsShift ImageOperands, params Instruction[] Operands)
        {
            Instruction ImageSparseFetch = CreateOperationWithResulType(Op.OpImageSparseFetch, ResultType, Image.ResultTypeId, Coordinate.ResultTypeId, (uint)ImageOperands);
            ImageSparseFetch.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSparseFetch);
        }

        public Instruction ImageSparseDrefGather(Instruction ResultType, Instruction Image, Instruction Coordinate, Instruction Dref)
        {
            return EmitOperationWithResulType(Op.OpImageSparseDrefGather, ResultType, Image.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId);
        }

        public Instruction ImageSparseDrefGather(Instruction ResultType, Instruction Image, Instruction Coordinate, Instruction Dref, ImageOperandsShift ImageOperands, params Instruction[] Operands)
        {
            Instruction ImageSparseDrefGather = CreateOperationWithResulType(Op.OpImageSparseDrefGather, ResultType, Image.ResultTypeId, Coordinate.ResultTypeId, Dref.ResultTypeId, (uint)ImageOperands);
            ImageSparseDrefGather.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSparseDrefGather);
        }

        public Instruction ImageSparseTexelsResident(Instruction ResultType, Instruction ResidentCode)
        {
            return EmitOperationWithResulType(Op.OpImageSparseTexelsResident, ResultType, ResidentCode.ResultTypeId);
        }

        public Instruction ImageSparseRead(Instruction ResultType, Instruction Image, Instruction Coordinate)
        {
            return EmitOperationWithResulType(Op.OpImageSparseRead, ResultType, Image.ResultTypeId, Coordinate.ResultTypeId);
        }

        public Instruction ImageSparseRead(Instruction ResultType, Instruction Image, Instruction Coordinate, ImageOperandsShift ImageOperands, params Instruction[] Operands)
        {
            Instruction ImageSparseRead = CreateOperationWithResulType(Op.OpImageSparseRead, ResultType, Image.ResultTypeId, Coordinate.ResultTypeId, (uint)ImageOperands);
            ImageSparseRead.PushOperandResultTypeId(Operands);

            return EmitCode(ImageSparseRead);
        }
    }
}
