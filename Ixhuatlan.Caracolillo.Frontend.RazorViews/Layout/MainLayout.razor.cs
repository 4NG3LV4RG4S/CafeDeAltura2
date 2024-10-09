namespace Ixhuatlan.Caracolillo.Frontend.RazorViews.Layout;

public partial class MainLayout
{
    private bool DrawerOpen = true;
    bool _expanded = true;

    private void OnExpandCollapseClick()
    {
        _expanded = !_expanded;
    }
}