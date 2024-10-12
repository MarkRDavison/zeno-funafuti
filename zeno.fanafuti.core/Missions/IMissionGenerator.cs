namespace zeno.fanafuti.core.Missions;

public interface IMissionGenerator
{
    Mission GenerateMission(MissionGenerationParameters parameters);
}
