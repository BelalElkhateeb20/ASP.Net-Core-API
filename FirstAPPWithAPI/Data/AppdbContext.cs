using System;
using System.Collections.Generic;
using FirstAPPWithAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPPWithAPI.Data;

public partial class AppdbContext : DbContext
{
    public AppdbContext(DbContextOptions<AppdbContext> options)
        : base(options)
    {

    }
    public DbSet<Employee> employees { get; set; }
    public DbSet<Genre> genres { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Employee>();
    }

    
}
