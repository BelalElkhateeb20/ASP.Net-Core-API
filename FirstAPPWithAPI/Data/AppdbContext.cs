using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FirstAPPWithAPI.Data;

public partial class AppdbContext : DbContext
{
    public AppdbContext(DbContextOptions<AppdbContext> options)
        : base(options)
    {

    }
    public DbSet<Employee> employees { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }

    
}
