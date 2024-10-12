using Humanizer;
using zeno.fanafuti.core.Data;

namespace zeno.fanafuti.core.Views;

public sealed class MilitaryBaseView : View
{
    private readonly WorldData _worldData;
    private readonly IViewNavigationService _viewNavigationService;
    private readonly IFontManager _fontManager;
    private int? _baseId;

    private readonly Button _back;

    public MilitaryBaseView(
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
            OnClick = () => _viewNavigationService.OpenIsland(Base.IslandId)
        };
    }

    private MilitaryBase Base => _worldData.MilitaryBases.First(_ => _.Id == _baseId);
    private Faction Faction => _worldData.Factions.First(_ => _.Id == Base.FactionId);

    public void InitialiseBase(int baseId)
    {
        _baseId = baseId;
    }

    public override void Update(float delta)
    {
        _back.Update(delta);
    }

    public override void Draw()
    {
        var bounds = ViewUtilities.DrawBorderedBackground(ViewUtilities.GetToolbarLessBounds(), 8);

        Raylib.DrawTextEx(_fontManager.GetFont("DEBUG"), Base.Name, bounds.Position, 48, 1, Color.Black);
        bounds.Y += 48 + 8;
        bounds.Height -= 48 + 8;

        var size = Raylib.MeasureTextEx(_fontManager.GetFont("DEBUG"), "Faction: " + Faction.Name, 32, 1);
        Raylib.DrawTextEx(_fontManager.GetFont("DEBUG"), "Faction: " + Faction.Name, bounds.Position, 32, 1, Color.DarkGray);
        Raylib.DrawTextEx(_fontManager.GetFont("DEBUG"), "Type: " + Base.Type.Humanize(LetterCasing.Sentence), bounds.Position + new Vector2(size.X + 16, 0), 32, 1, Color.DarkGray);
        bounds.Y += 32 + 8;
        bounds.Height -= 32 + 8;

        if (Base.Type == MiltaryBaseType.AirBase)
        {
            if (Base.Aircraft.Any())
            {
                Raylib.DrawTextEx(_fontManager.GetFont("DEBUG"), "Aircraft", bounds.Position, 32, 1, Color.DarkGray);
                bounds.Y += 32 + 8;
                bounds.Height -= 32 + 8;

                foreach (var aircraftGroup in Base.Aircraft.GroupBy(_ => _.Type))
                {
                    Raylib.DrawTextEx(_fontManager.GetFont("DEBUG"), $" - {aircraftGroup.Key} (x{aircraftGroup.Count():N0})", bounds.Position + new Vector2(8, 0), 32, 1, Color.DarkGray);
                    bounds.Y += 32 + 8;
                    bounds.Height -= 32 + 8;
                }
            }
        }

        _back.Draw();
    }
}
