using zeno.fanafuti.core.Data;

namespace zeno.fanafuti.core.Views;

public sealed class MapView : View
{
    private readonly WorldData _worldData;
    private readonly IViewNavigationService _viewNavigationService;

    public MapView(
        WorldData worldData,
        IViewNavigationService viewNavigationService)
    {
        _worldData = worldData;
        _viewNavigationService = viewNavigationService;
    }

    public int? SelectedIslandId { get; set; }

    public DateTime? _locationLastClicked;
    public Vector2? _locationLastClickedAt;

    public override void Update(float delta)
    {
        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            var selectedIsland = false;
            var mousePosition = Raylib.GetMousePosition();

            foreach (var location in _worldData.Islands)
            {
                if ((mousePosition - location.Position).Length() < location.Size)
                {
                    SelectedIslandId = location.Id;
                    selectedIsland = true;

                    var clickedAt = DateTime.Now;

                    if (_locationLastClicked is not null && _locationLastClickedAt is not null)
                    {
                        var clickTime = clickedAt - _locationLastClicked.Value;

                        if (clickTime < TimeSpan.FromMilliseconds(500) &&
                            (_locationLastClickedAt.Value - mousePosition).Length() < 16) // TODO: Better helpers
                        {
                            _viewNavigationService.OpenIsland(location.Id);
                        }
                    }

                    _locationLastClicked = clickedAt;
                    _locationLastClickedAt = mousePosition;

                    break;
                }
            }

            if (!selectedIsland)
            {
                SelectedIslandId = null;
                _locationLastClicked = null;
            }
        }
    }

    public override void Draw()
    {
        foreach (var island in _worldData.Islands)
        {
            var faction = _worldData.Factions.First(_ => _.Id == island.FactionId);

            if (island.Id == SelectedIslandId)
            {
                Raylib.DrawCircle((int)island.Position.X, (int)island.Position.Y, island.Size + 8, Color.White);
            }

            Raylib.DrawCircle((int)island.Position.X, (int)island.Position.Y, island.Size, faction.Color);

            foreach (var b in _worldData.MilitaryBases.Where(_ => _.IslandId == island.Id))
            {
                Raylib.DrawCircle((int)(island.Position.X + b.IslandOffset.X), (int)(island.Position.Y + b.IslandOffset.Y), b.Size, Color.Magenta);
            }
        }
    }
}
