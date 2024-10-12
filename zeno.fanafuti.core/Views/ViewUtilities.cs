namespace zeno.fanafuti.core.Views;

public static class ViewUtilities
{
    public static Rectangle GetToolbarLessBounds() => new(
        0,
        48,
        Raylib.GetRenderWidth(),
        Raylib.GetRenderHeight() - 48);

    public static Rectangle DrawBorderedBackground(Rectangle bounds, int margin)
    {
        Raylib.DrawRectangle((int)bounds.X, (int)bounds.Y, (int)bounds.Width, (int)bounds.Height, Color.DarkGray);
        bounds.X += margin;
        bounds.Y += margin;
        bounds.Width -= margin * 2;
        bounds.Height -= margin * 2;

        Raylib.DrawRectangle((int)bounds.X, (int)bounds.Y, (int)bounds.Width, (int)bounds.Height, Color.LightGray);
        bounds.X += margin;
        bounds.Y += margin;
        bounds.Width -= margin * 2;
        bounds.Height -= margin * 2;

        return bounds;
    }
}
