using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using RulerHub.Shared.Entities.Warehouses;

namespace WKeeper.Web.Components.Warehouses.Pages;

public partial class WarehouseOverseePanel : IDialogContentComponent<Warehouse>
{
    [Parameter]
    public Warehouse Content { get; set; } = default!;

    private void GotoItemManage()
    {
        NavigationManager.NavigateTo("item/home");
    }
}
