namespace zeno.fanfuti.engine.ui.Constraints;

public class CenterConstraint : UiConstraint
{
    private readonly bool _horizontal;
    private readonly UiConstraint _sizeConstraint;

    public CenterConstraint(
        bool horizontal,
        UiConstraint sizeConstraint)
    {
        _horizontal = horizontal;
        _sizeConstraint = sizeConstraint;
    }

    public override float MeasureValue(Rectangle parent)
    {
        if (_horizontal)
        {
            var width = _sizeConstraint.MeasureValue(parent);
            return (parent.Width - width) / 2;
        }
        else
        {
            var height = _sizeConstraint.MeasureValue(parent);
            return (parent.Height - height) / 2;
        }
    }
}
