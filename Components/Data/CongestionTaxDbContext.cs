using System.Reflection;
using congestionTax.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace congestionTax.Components.Data;

public class CongestionTaxDbContext(DbContextOptions<CongestionTaxDbContext> options) 
    : DbContext(options)
{
    public DbSet<City> Cities { get; set; }
    public DbSet<TaxPeriod> TaxPeriods { get; set; }
    public DbSet<Holiday> Holidays { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Console.WriteLine("fffff");
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}