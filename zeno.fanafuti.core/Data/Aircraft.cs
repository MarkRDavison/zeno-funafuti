namespace zeno.fanafuti.core.Data;

public sealed class Aircraft
{
    public string Type { get; set; } = string.Empty;
    public AircraftReadiness Readiness { get; } = new();
}
