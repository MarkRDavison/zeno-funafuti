namespace zeno.fanafuti.core.Data;

public sealed class Island
{
    public int Id { get; set; }
    public int FactionId { get; set; }
    public string Name { get; set; } = string.Empty;
    public Vector2 Position { get; set; }
    public int Size { get; set; } = 64;
}
