namespace congestionTax.Components.Models;

public class Holiday
{
    public int Id { get; set; }
    public DateTime HolidayDate { get; set; }

    public int CityId { get; set; }
    public City City { get; set; }
}