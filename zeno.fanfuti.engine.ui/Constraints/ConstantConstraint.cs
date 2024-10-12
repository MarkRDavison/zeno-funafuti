namespace zeno.fanfuti.engine.ui.Constraints;

public sealed class ConstantConstraint : UiConstraint
{
    public ConstantConstraint(float value)
    {
        Value = value;
    }

    public float Value { get; }

    public override float MeasureValue(Rectangle parent)
    {
        return Math.Clamp(Value, parent.X, parent.X + parent.Width);
    }
}
