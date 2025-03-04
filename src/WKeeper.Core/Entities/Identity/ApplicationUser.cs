using Microsoft.AspNetCore.Identity;
using WKeeper.Core.Entities.Enterprices;

namespace WKeeper.Core.Entities.Identity;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public List<Enterprice> Enterprices { get; set; } = [];
}
