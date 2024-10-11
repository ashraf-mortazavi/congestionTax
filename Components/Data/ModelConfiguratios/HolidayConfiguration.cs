using congestionTax.Components.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace congestionTax.Components.Data.ModelConfiguratios;

public class HolidayConfiguration : IEntityTypeConfiguration<Holiday>
{
    public void Configure(EntityTypeBuilder<Holiday> builder)
    {
        builder.ToTable("Holidays");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.HolidayDate)
            .IsRequired();

        builder.Property(x => x.CityId)
            .IsRequired();

        builder.HasOne(c => c.City)
            .WithMany(c => c.Holidays)
            .HasForeignKey(c => c.CityId);
    }
}