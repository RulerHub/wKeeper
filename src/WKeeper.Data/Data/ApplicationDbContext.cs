using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RulerHub.Shared.Entities.Enterprises;
using RulerHub.Shared.Entities.Identity;
using RulerHub.Shared.Entities.Logistic;
using RulerHub.Shared.Entities.Sales;
using RulerHub.Shared.Entities.Warehouses;

namespace WKeeper.Data.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    // Enterprice
    public DbSet<Enterprise> Enterprises { get; set; }
    // Logistic
    public DbSet<Provider> Providers { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Return> Returns { get; set; }
    // Sales
    public DbSet<Department> Departments { get; set; }
    // Warehouse
    public DbSet<Category> Categories { get; set; }
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
