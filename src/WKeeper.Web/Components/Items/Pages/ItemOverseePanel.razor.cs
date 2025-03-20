using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using RulerHub.Shared.Entities.Warehouses;

namespace WKeeper.Web.Components.Items.Pages;

public partial class ItemOverseePanel : IDialogContentComponent<Item>
{
    [Parameter]
    public Item Content { get; set; } = default!;
}
