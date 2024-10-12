namespace zeno.fanfuti.engine.ui.Components;

public class Panel : ComponentBase
{
    public int BorderThickness { get; set; } = 4;
    public Color BorderColor { get; set; } = Color.DarkGray;
    public Color Color { get; set; } = Color.LightGray;


    public override void Draw()
    {
        if (BorderThickness > 0)
        {
            Raylib.DrawRectangle((int)LastMeasurement.X, (int)LastMeasurement.Y, (int)LastMeasurement.Width, (int)LastMeasurement.Height, BorderColor);
            Raylib.DrawRectangle((int)LastMeasurement.X + BorderThickness, (int)LastMeasurement.Y + BorderThickness, (int)LastMeasurement.Width - 2 * BorderThickness, (int)LastMeasurement.Height - 2 * BorderThickness, Color);
        }
        else
        {
            Raylib.DrawRectangle((int)LastMeasurement.X, (int)LastMeasurement.Y, (int)LastMeasurement.Width, (int)LastMeasurement.Height, Color);
        }

        foreach (var c in Children)
        {
            c.Draw();
        }
    }
}
