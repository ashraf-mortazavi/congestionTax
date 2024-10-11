using congestionTax.Components.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace congestionTax.Components.Data.ModelConfiguratios;

public class TaxPeriodConfiguration : IEntityTypeConfiguration<TaxPeriod>
{
    public void Configure(EntityTypeBuilder<TaxPeriod> builder)
    {
        builder.ToTable("TaxPeriods");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.StartTime)
            .IsRequired();

        builder.Property(x => x.EndTime)
            .IsRequired();

        builder.Property(x => x.Amount)
            .IsRequired();

        builder.Property(x => x.CityId)
            .IsRequired();

        builder.HasOne(c => c.City)
            .WithMany(c => c.TaxPeriods)
            .HasForeignKey(c => c.CityId);
    }
}