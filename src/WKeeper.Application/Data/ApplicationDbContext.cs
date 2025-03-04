using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using wKeeper.Core.Entities.Enterprices;
using wKeeper.Core.Entities.Identity;
using wKeeper.Core.Entities.Logistic;
using wKeeper.Core.Entities.Sales;
using wKeeper.Core.Entities.Warehouses;

namespace wKeeper.Application.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    // Enterprice
    public DbSet<Enterprice> Enterprices { get; set; }
    // Logistic
    public DbSet<Provider> Providers { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Return> Returns { get; set; }
    // Sales
    public DbSet<Client> Clients { get; set; }
    public DbSet<Sale> Sales { get; set; }
    // Warehouse
    public DbSet<Category> Categories { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        List<IdentityRole> roles =
        [
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "Sales",
                NormalizedName = "SALES"
            },
            new IdentityRole
            {
                Name = "Logistic",
                NormalizedName = "LOGISTIC"
            },
        ];
        builder.Entity<IdentityRole>().HasData(roles);
    }
}
