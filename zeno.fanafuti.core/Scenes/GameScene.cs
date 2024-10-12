using zeno.fanafuti.core.Data;

namespace zeno.fanafuti.core.Scenes;

public sealed class GameScene : IScene
{
    enum ViewState
    {
        MapView = 0,
        IslandView = 1,
        MilitaryBaseView = 2
    }


    private readonly IGameTimeService _gameTimeService;
    private readonly IFontManager _fontManager;
    private readonly IViewNavigationService _viewNavigationService;
    private readonly MapView _mapView;
    private readonly IslandView _locationView;
    private readonly MilitaryBaseView _militaryBaseView;
    private readonly WorldData _worldData;

    private ViewState _viewState = ViewState.MapView;

    private Dictionary<ViewState, List<View>> _stateViews = [];

    public GameScene(
        IGameTimeService gameTimeService,
        IFontManager fontManager,
        IViewNavigationService viewNavigationService,
        MapView mapView,
        IslandView locationView,
        MilitaryBaseView militaryBaseView,
        WorldData worldData)
    {
        _gameTimeService = gameTimeService;
        _viewNavigationService = viewNavigationService;

        {
            worldData.Factions.Add(new Faction
            {
                Name = "Player",
                Id = 1,
                Color = Color.Green
            });

            worldData.Factions.Add(new Faction
            {
                Name = "Evil",
                Id = 2,
                Color = Color.Red
            });

            worldData.Factions.Add(new Faction
            {
                Name = "Neutral",
                Id = 3,
                Color = Color.Blue
            });

            worldData.Islands.Add(new Island
            {
                Id = 1,
                FactionId = 1,
                Name = "Player Capital",
                Size = 32,
                Position = new Vector2(256, 256)
            });

            worldData.Islands.Add(new Island
            {
                Id = 2,
                FactionId = 2,
                Name = "Evil Capital",
                Size = 96,
                Position = new Vector2(928, 384)
            });

            worldData.Islands.Add(new Island
            {
                Id = 3,
                FactionId = 3,
                Name = "Neutral Capital",
                Size = 128,
                Position = new Vector2(512, 496)
            });

            worldData.MilitaryBases.Add(new MilitaryBase
            {
                Id = 1,
                FactionId = 1,
                IslandId = 1,
                IslandOffset = new Vector2(16, 8),
                Size = 8.0f,
                Name = "Air Base Alpha",
                Type = MiltaryBaseType.AirBase,
                Aircraft =
                {
                    new() { Type = "F16" },
                    new() { Type = "F16" },
                    new() { Type = "F16" },
                    new() { Type = "F16" },

                    new() { Type = "F18" },
                    new() { Type = "F18" },
                    new() { Type = "F18" },

                    new() { Type = "AWACS" },
                    new() { Type = "AWACS" }
                }
            });

            worldData.MilitaryBases.Add(new MilitaryBase
            {
                Id = 2,
                FactionId = 1,
                IslandId = 1,
                IslandOffset = new Vector2(-16, 8),
                Size = 6.0f,
                Name = "Secundus Floating Dirigible",
                Type = MiltaryBaseType.AirBase,
                Aircraft =
                {
                    new() { Type = "BLIMP" },
                    new() { Type = "BLIMP" },
                    new() { Type = "BLIMP" },
                    new() { Type = "BLIMP" },
                }
            });
        }

        _fontManager = fontManager;
        _mapView = mapView;
        _locationView = locationView;
        _militaryBaseView = militaryBaseView;
        _worldData = worldData;

        _stateViews.Add(ViewState.MapView, [_mapView]);
        _stateViews.Add(ViewState.IslandView, [_locationView]);
        _stateViews.Add(ViewState.MilitaryBaseView, [_militaryBaseView]);
    }

    public void Init()
    {
        _mapView.Init();

        // TODO: DISPOSE
        _viewNavigationService.OnOpenIslandRequested += OnOpenIslandRequested;
        _viewNavigationService.OnOpenMapRequested += OnOpenMapRequested;
        _viewNavigationService.OnOpenMilitaryBaseRequested += OnOpenMilitaryBaseRequested;
    }

    private void OnOpenMilitaryBaseRequested(object? sender, int e)
    {
        _viewState = ViewState.MilitaryBaseView;
        _militaryBaseView.InitialiseBase(e);
    }

    private void OnOpenMapRequested(object? sender, EventArgs e)
    {
        _viewState = ViewState.MapView;
    }

    private void OnOpenIslandRequested(object? sender, int e)
    {
        _viewState = ViewState.IslandView;
        _locationView.InitialiseIsland(e);
    }

    public void Update(float delta)
    {
        foreach (var view in _stateViews[_viewState])
        {
            view.Update(delta);
        }

        if (Raylib.IsKeyPressed(KeyboardKey.F1))
        {
            _gameTimeService.Tick(TimeSpan.FromHours(1));
        }
        if (Raylib.IsKeyPressed(KeyboardKey.F2))
        {
            _gameTimeService.Tick(TimeSpan.FromMinutes(15));
        }
    }

    public void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.SkyBlue);

        foreach (var view in _stateViews[_viewState])
        {
            view.Draw();
        }

        {
            Raylib.DrawRectangle(0, 0, Raylib.GetRenderWidth(), 48, Color.LightGray);
            Raylib.DrawTextEx(_fontManager.GetFont("DEBUG"), _gameTimeService.CurrentGameUtcTime.ToString("HH:mm - d MMMM yyyy"), new Vector2(8, 8), 32, 1, Color.Black);
        }

        //Raylib.DrawFPS(16, 16);

        Raylib.EndDrawing();
    }
}
