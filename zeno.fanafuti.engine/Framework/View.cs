namespace zeno.fanafuti.engine.Framework;

public abstract class View
{
    public virtual void Init() { }
    public abstract void Update(float delta);
    public abstract void Draw();
}
