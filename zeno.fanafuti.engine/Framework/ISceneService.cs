namespace zeno.fanafuti.engine.Framework;

public interface ISceneService
{
    void SetScene<TScene>() where TScene : IScene;

    void Init();
}
