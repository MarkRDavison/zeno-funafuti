namespace zeno.fanfuti.engine.ui.Constraints;

public class ConstraintsGroup
{
    public ConstraintsGroup()
    {
        X = new ConstantConstraint(0.0f);
        Y = new ConstantConstraint(0.0f);
        W = new PercentageConstraint(100.0f, true);
        H = new PercentageConstraint(100.0f, false);
    }
    public ConstraintsGroup(UiConstraint x, UiConstraint y, UiConstraint w, UiConstraint h)
    {
        X = x;
        Y = y;
        W = w;
        H = h;
    }

    public UiConstraint X { get; }
    public UiConstraint Y { get; }
    public UiConstraint W { get; }
    public UiConstraint H { get; }

    public Rectangle Measure(Rectangle parent)
    {
        return new(
            X.MeasureValue(parent),
            Y.MeasureValue(parent),
            W.MeasureValue(parent),
            H.MeasureValue(parent));
    }
}
