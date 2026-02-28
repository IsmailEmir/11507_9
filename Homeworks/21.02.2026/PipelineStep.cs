

public abstract class PipelineStep<TIn, TOut>
{
    public abstract TOut Process(TIn input);

    public PipelineStep<TIn, TNextOut> Step<TNextOut>(PipelineStep<TOut, TNextOut> nextStep)
    {
        return new WrapperStep<TIn, TOut, TNextOut>(this, nextStep);
    }
}

public class WrapperStep<TIn, TMid, TOut> : PipelineStep<TIn, TOut>
{
    private readonly PipelineStep<TIn, TMid> _firstStep;
    private readonly PipelineStep<TMid, TOut> _secondStep;

    public WrapperStep(PipelineStep<TIn, TMid> first, PipelineStep<TMid, TOut> second)
    {
        _firstStep = first;
        _secondStep = second;
    }

    public override TOut Process(TIn input)
    {
        TMid midRes = _firstStep.Process(input);
        return _secondStep.Process(midRes);
    }
}
