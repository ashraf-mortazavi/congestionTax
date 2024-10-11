namespace congestionTax.Components.Models;

public class TaxPeriod
{
    public int Id { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int Amount { get; set; }

    public int CityId { get; set; }
    public City City { get; set; }
}