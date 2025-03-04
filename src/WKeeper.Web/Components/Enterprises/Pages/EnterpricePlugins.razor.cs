using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace WKeeper.Web.Components.Enterprises.Pages;

public partial class EnterpricePlugins
{
    FluentHorizontalScroll _horizontalScroll = default!;

    [Parameter]
    public int WarehouseCount { get; set; }

    private void GotoWarehouseManage()
    {
        NavigationManager.NavigateTo("warehouse/home");
    }

}
