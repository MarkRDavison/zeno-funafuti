namespace zeno.fanfuti.engine.ui;

public abstract class ComponentBase
{
    public static IServiceProvider Services { get; set; } = null!;
    public virtual void Update(float delta)
    {

    }

    public abstract void Draw();

    public void AddChild(ComponentBase child)
    {
        Children.Add(child);
    }

    internal void Measure(Rectangle maxBounds)
    {
        LastMeasurement = Constraints.Measure(maxBounds);
        foreach (var child in Children)
        {
            child.Measure(LastMeasurement);
        }
    }

    public virtual Vector2 DesiredSize()
    {
        return new Vector2(-1, -1);
    }

    public IList<ComponentBase> Children { get; } = [];
    public ConstraintsGroup Constraints { get; set; } = new();
    protected Rectangle LastMeasurement { get; set; } = new();
}
