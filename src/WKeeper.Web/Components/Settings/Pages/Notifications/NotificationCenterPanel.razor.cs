using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;


namespace WKeeper.Web.Components.Settings.Pages.Notifications;

public partial class NotificationCenterPanel
{
    [Parameter]
    public GlobalState Content { get; set; } = default!;
}
