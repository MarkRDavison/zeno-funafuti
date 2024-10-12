namespace zeno.fanfuti.engine.ui.Constraints;

public sealed class AsRequiredConstraint : UiConstraint // TODO: Limit to size, not position
{
    private readonly bool _horizontal;
    private readonly ComponentBase component;

    public AsRequiredConstraint(
        bool horizontal,
        ComponentBase component)
    {
        _horizontal = horizontal;
        this.component = component;
    }

    public override float MeasureValue(Rectangle parent)
    {
        throw new NotImplementedException();
    }
}
