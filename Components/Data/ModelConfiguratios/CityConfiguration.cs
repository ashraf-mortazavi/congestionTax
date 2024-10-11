using congestionTax.Components.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace congestionTax.Components.Data.ModelConfiguratios;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.MaxDailyTax)
            .IsRequired();

        builder.HasMany(c => c.TaxPeriods)
            .WithOne(c => c.City)
            .HasForeignKey(c => c.CityId);

        builder.HasMany(c => c.Holidays)
            .WithOne(c => c.City)
            .HasForeignKey(c => c.CityId);

        builder.HasMany(c => c.Vehicles)
            .WithOne(c => c.City)
            .HasForeignKey(c => c.CityId);
    }
}