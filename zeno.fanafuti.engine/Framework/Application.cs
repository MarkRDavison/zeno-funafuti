namespace zeno.fanafuti.engine.Framework;

public class Application
{
    private readonly IServiceProvider _serviceProvider;

    public Application(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Init(string title)
    {
        //Raylib.SetConfigFlags(ConfigFlags.TopmostWindow);
        //Raylib.SetConfigFlags(ConfigFlags.MaximizedWindow);
        //Raylib.SetConfigFlags(ConfigFlags.UndecoratedWindow);
        //var monitor = Raylib.GetCurrentMonitor();
        //var width = Raylib.GetMonitorWidth(monitor);
        //var height = Raylib.GetMonitorHeight(monitor);
        //Raylib.SetWindowSize(width, height);

        Raylib.SetConfigFlags(ConfigFlags.VSyncHint);
        Raylib.InitWindow(1440, 900, title);
        Raylib.InitAudioDevice();
        Raylib.SetExitKey(KeyboardKey.Null);
        //Raylib.SetWindowIcon(Raylib.LoadImage("Assets/Textures/icon.png"));

        await Task.CompletedTask;
    }

    public void Stop()
    {
        Raylib.CloseWindow();
    }

    public Task Start(CancellationToken token)
    {
        while (!Raylib.WindowShouldClose()) // Detect window close button or ESC key
        {
            if (token.IsCancellationRequested)
            {
                break;
            }

            CurrentScene?.Update(Raylib.GetFrameTime());

            CurrentScene?.Draw();
        }

        return Task.CompletedTask;
    }

    public void SetScene(IScene? scene)
    {
        CurrentScene = scene;
    }

    public IScene? CurrentScene { get; private set; }

}
