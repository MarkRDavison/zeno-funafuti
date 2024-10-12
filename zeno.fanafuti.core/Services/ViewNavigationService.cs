namespace zeno.fanafuti.core.Services;

public sealed class ViewNavigationService : IViewNavigationService
{
    public event EventHandler<int> OnOpenIslandRequested = default!;
    public event EventHandler OnOpenMapRequested = default!;
    public event EventHandler<int> OnOpenMilitaryBaseRequested = default!;

    public void OpenIsland(int locationId)
    {
        if (OnOpenIslandRequested is not null)
        {
            OnOpenIslandRequested(this, locationId);
        }
    }

    public void OpenMap()
    {
        if (OnOpenMapRequested is not null)
        {
            OnOpenMapRequested(this, EventArgs.Empty);
        }
    }

    public void OpenMilitaryBase(int baseId)
    {
        if (OnOpenMilitaryBaseRequested is not null)
        {
            OnOpenMilitaryBaseRequested(this, baseId);
        }
    }
}
