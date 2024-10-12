using zeno.fanafuti.core.Data;

namespace zeno.fanafuti.core.Views;

public sealed class IslandView : View
{
    private readonly WorldData _worldData;
    private readonly IViewNavigationService _viewNavigationService;
    private readonly IFontManager _fontManager;

    private readonly Button _back;
    private readonly List<Button> _baseButtons = [];
    private int? _locationId;

    public IslandView(
        WorldData worldData,
        IViewNavigationService viewNavigationService,
        IFontManager fontManager)
    {
        _worldData = worldData;
        _viewNavigationService = viewNavigationService;
        _fontManager = fontManager;

        _back = new Button
        {
            Bounds = new Rectangle(Raylib.GetRenderWidth() - 200 - 8 - 8, 64, 200, 50),
            Label = "Back",
            OnClick = _viewNavigationService.OpenMap
        };
    }

    private Island Island => _worldData.Islands.First(_ => _.Id == _locationId);
    private Faction Faction => _worldData.Factions.First(_ => _.Id == Island.FactionId);

    public void InitialiseIsland(int islandId)
    {
        _locationId = islandId;
        _baseButtons.Clear();
        int i = 0;
        foreach (var b in _worldData.MilitaryBases.Where(_ => _.IslandId == _locationId))
        {
            _baseButtons.Add(new Button
            {
                Bounds = new Rectangle(64, 64 * (i + 1), 512, 50),
                Label = b.Name,
                OnClick = () => _viewNavigationService.OpenMilitaryBase(b.Id)
            });
            i++;
        }
    }

    public override void Update(float delta)
    {
        _back.Update(delta);
        foreach (var b in _baseButtons)
        {
            b.Update(delta);
        }
    }

    public override void Draw()
    {
        var bounds = ViewUtilities.DrawBorderedBackground(ViewUtilities.GetToolbarLessBounds(), 8);

        Raylib.DrawTextEx(_fontManager.GetFont("DEBUG"), Island.Name, bounds.Position, 48, 1, Color.Black);
        bounds.Y += 48 + 8;
        bounds.Height -= 48 + 8;

        Raylib.DrawTextEx(_fontManager.GetFont("DEBUG"), "Faction: " + Faction.Name, bounds.Position, 32, 1, Color.DarkGray);
        bounds.Y += 32 + 8;
        bounds.Height -= 32 + 8;

        if (_worldData.MilitaryBases.Where(_ => _.IslandId == _locationId).ToList() is { } bases && bases.Count > 0)
        {
            Raylib.DrawTextEx(_fontManager.GetFont("DEBUG"), "Bases: ", bounds.Position, 32, 1, Color.DarkGray);
            bounds.Y += 32 + 8;
            bounds.Height -= 32 + 8;

            foreach (var (b, bb) in bases.Zip(_baseButtons))
            {
                bb.Bounds = new Rectangle(bb.Bounds.X, bounds.Position.Y, bb.Bounds.Size);

                bounds.Y += 54;
                bounds.Height -= 54;

                bb.Draw();
            }
        }

        _back.Draw();
    }
}
