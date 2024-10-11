using congestionTax.Components.Models.Enums;

namespace congestionTax.Components.Models;

public class Vehicle
{
    public int Id { get; set; }
    public VehicleType VehicleType { get; set; }
    
    public int CityId { get; set; }
    public City City { get; set; }
}