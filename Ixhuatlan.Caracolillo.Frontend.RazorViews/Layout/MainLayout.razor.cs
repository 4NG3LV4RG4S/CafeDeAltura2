namespace Ixhuatlan.Caracolillo.Frontend.RazorViews.Layout;

public partial class MainLayout
{
    private bool DrawerOpen = true;
    bool _expanded = false;

    private void OnExpandCollapseClick()
    {
        _expanded = !_expanded;
    }
}