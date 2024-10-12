namespace zeno.fanfuti.engine.ui.Constraints;

public class PercentageConstraint : UiConstraint
{
    private readonly bool _horizontal;
    public PercentageConstraint(float value, bool horizontal)
    {
        _horizontal = horizontal;
        Value = value;
    }

    public float Value { get; }

    public override float MeasureValue(Rectangle parent)
    {
        return (Value / 100.0f) * (_horizontal ? parent.Width : parent.Height);
    }
}
