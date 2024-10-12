namespace zeno.fanafuti.core.Services;

public sealed class GameTimeService : IGameTimeService
{

    public GameTimeService()
    {
        CurrentGameUtcTime = new DateTime(2024, 1, 15, 13, 30, 0);
    }

    public DateTime CurrentGameUtcTime { get; private set; }

    public void Tick(TimeSpan offset)
    {
        CurrentGameUtcTime = CurrentGameUtcTime.Add(offset);
    }
}
