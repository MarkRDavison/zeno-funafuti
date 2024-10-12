namespace zeno.fanafuti.core.Missions;

public sealed class MissionIntel
{
    public ConfidenceLevel Confidence { get; set; } = ConfidenceLevel.None;
    public Dictionary<string, int> Detected { get; set; } = [];
    public Dictionary<string, int> Actual { get; set; } = [];
    public DateTime DetectedDecisionPoint { get; set; }
    public DateTime ActualDecisionPoint { get; set; }
}
