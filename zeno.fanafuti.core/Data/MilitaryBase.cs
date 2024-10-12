namespace zeno.fanafuti.core.Data;

public enum MiltaryBaseType
{
    AirBase
}

public class MilitaryBase
{
    public int Id { get; set; }
    public int FactionId { get; set; }
    public int IslandId { get; set; }
    public string Name { get; set; } = string.Empty;
    public Vector2 IslandOffset { get; set; }
    public float Size { get; set; } = 16.0f;
    public MiltaryBaseType Type { get; set; } = MiltaryBaseType.AirBase;
    public List<Aircraft> Aircraft { get; } = [];
    public MilitaryBaseReadiness Readiness { get; } = new();
}
