using System;
using Company_website.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company_website.Models.Context;

public class AppDbContext:DbContext
{
    public AppDbContext():base() { }
    public AppDbContext(DbContextOptions options):base(options)
    {
        
    }
    public DbSet<Employee> Employees {get; set;}
    public DbSet<Company> company {get; set;}
}
