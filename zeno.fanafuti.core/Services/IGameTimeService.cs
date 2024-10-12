namespace zeno.fanafuti.core.Services;

public interface IGameTimeService
{
    DateTime CurrentGameUtcTime { get; }

    void Tick(TimeSpan offset);
}
