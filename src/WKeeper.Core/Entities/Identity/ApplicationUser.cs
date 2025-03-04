using Microsoft.AspNetCore.Identity;
using wKeeper.Core.Entities.Enterprices;

namespace wKeeper.Core.Entities.Identity;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public List<Enterprice> Enterprices { get; set; } = [];
}
