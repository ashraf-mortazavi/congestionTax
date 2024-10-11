using congestionTax.Components.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace congestionTax.Components.Data.ModelConfiguratios;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
  
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicles");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.VehicleType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.CityId)
            .IsRequired();

        builder.HasOne(c => c.City)
            .WithMany(c => c.Vehicles)
            .HasForeignKey(c => c.CityId);
    }
}