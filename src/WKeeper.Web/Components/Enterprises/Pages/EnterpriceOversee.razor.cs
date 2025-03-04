using Microsoft.AspNetCore.Components.Authorization;
using WKeeper.Core.Entities.Enterprices;


namespace WKeeper.Web.Components.Enterprises.Pages;

public partial class EnterpriceOversee
{
    public Enterprice? Enterprice { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity.IsAuthenticated)
        {
            var appUser = await UserManager.GetUserAsync(user);
            if (appUser != null)
            {
                Enterprice = await EnterpriceService.GetEnterpriceAsync(appUser.Id);
            }
        }
    }
}
