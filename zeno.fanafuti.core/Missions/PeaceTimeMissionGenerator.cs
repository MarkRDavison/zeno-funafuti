using zeno.fanafuti.core.Data;

namespace zeno.fanafuti.core.Missions;

public sealed class PeaceTimeMissionGenerator : IMissionGenerator
{
    private readonly IGameTimeService _gameTimeService;

    public PeaceTimeMissionGenerator(IGameTimeService gameTimeService)
    {
        _gameTimeService = gameTimeService;
    }

    public Mission GenerateMission(MissionGenerationParameters parameters)
    {
        var detectionTime = _gameTimeService.CurrentGameUtcTime;

        return new Mission
        {
            Type = "Interception",
            DetectedAt = detectionTime,
            Island = new MissionLocation
            {
                Distance = 1_200
            },
            Intel = new MissionIntel
            {
                Confidence = ConfidenceLevel.Medium,
                Detected =
                {
                    { "Bomber", 3 },
                    { "Fighter", 1 }
                },
                Actual =
                {
                    { "Bomber", 3 },
                    { "Fighter", 7 }
                },
                DetectedDecisionPoint = detectionTime.AddHours(8),
                ActualDecisionPoint = detectionTime.AddHours(7)
            }
        };
    }
}
