namespace zeno.fanafuti.core.Missions;

public sealed class Mission
{
    public string Type { get; set; } = string.Empty;
    public DateTime DetectedAt { get; set; }
    public MissionLocation Island { get; set; } = new();
    public MissionIntel Intel { get; set; } = new();
}
