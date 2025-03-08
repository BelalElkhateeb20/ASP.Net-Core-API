
using FirstAPI.Data.IdentityMangement;
using FirstAPPWithAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace FirstAPPWithAPI.Data;
public partial class AppdbContext : IdentityDbContext<ApplicationUser>
{
    public AppdbContext(DbContextOptions<AppdbContext> options) : base(options)
    {

    }
    public DbSet<Employee> employees { get; set; }
    public DbSet<Genre> genres { get; set; }
    public DbSet<Movie> movies { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Ignore<Employee>();
    }
}
