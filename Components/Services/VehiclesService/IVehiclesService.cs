using congestionTax.Components.Models;

namespace congestionTax.Components.Services.VehiclesService;

public interface IVehiclesService
{
    Task<List<Vehicle>> GetVehiclesAsync(int cityId);
    Task AddOrUpdateVehicleAsync(Vehicle vehicle);
    Task RemoveVehicleAsync(int vehicleId);
}