namespace zeno.fanafuti.core.Services;

public interface IViewNavigationService
{
    void OpenIsland(int locationId);

    event EventHandler<int> OnOpenIslandRequested;

    void OpenMap();

    event EventHandler OnOpenMapRequested;

    void OpenMilitaryBase(int baseId);

    event EventHandler<int> OnOpenMilitaryBaseRequested;
}
