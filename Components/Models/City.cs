namespace congestionTax.Components.Models;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int MaxDailyTax { get; set; }
    public ICollection<TaxPeriod> TaxPeriods { get; set; }
    public ICollection<Holiday> Holidays { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; }
}