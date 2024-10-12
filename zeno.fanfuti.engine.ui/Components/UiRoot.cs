namespace zeno.fanfuti.engine.ui.Components;

public sealed class UiRoot
{
    public UiRoot()
    {
        Root = new Panel();
    }

    public Rectangle MaxBounds { get; set; }

    public void Update(float delta)
    {
        Root.Measure(MaxBounds);
        Root.Update(delta);
    }

    public ComponentBase Root { get; }

    public void Draw()
    {
        Raylib.DrawRectangleLines((int)MaxBounds.X, (int)MaxBounds.Y, (int)MaxBounds.Width, (int)MaxBounds.Height, Color.Green);
        Root.Draw();
    }
}
