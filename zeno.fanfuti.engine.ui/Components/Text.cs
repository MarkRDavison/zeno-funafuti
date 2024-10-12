
namespace zeno.fanfuti.engine.ui.Components;

public class Text : ComponentBase
{
    public Color Color { get; set; } = Color.Black;

    public string Content { get; set; } = string.Empty;
    public int FontSize { get; set; } = 32;

    public override void Draw()
    {
        if (string.IsNullOrEmpty(Content))
        {
            return;
        }

        Raylib.DrawText(Content, (int)LastMeasurement.X, (int)LastMeasurement.Y, FontSize, Color);
    }

    public override Vector2 DesiredSize()
    {
        return new Vector2(-1, FontSize);
    }
}
