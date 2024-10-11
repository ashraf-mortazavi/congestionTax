using congestionTax.Components.Data;
using congestionTax.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace congestionTax.Components.Services.VehiclesService;

public class VehiclesService (CongestionTaxDbContext context) : IVehiclesService
{
    private readonly CongestionTaxDbContext _context = context;
    
    public async Task<List<Vehicle>> GetVehiclesAsync(int cityId)
    {
        return await _context.Vehicles
            .Where(x => x.CityId == cityId)
            .ToListAsync();
    }

    public async Task AddOrUpdateVehicleAsync(Vehicle vehicle)
    {
        var item = await _context.Vehicles
            .FirstOrDefaultAsync(x => x.Id == vehicle.Id);

        if (item is null)
            _context.Vehicles.Add(vehicle);
        else
            _context.Vehicles.Update(vehicle);

        await _context.SaveChangesAsync();
    }

    public async Task RemoveVehicleAsync(int vehicleId)
    {
        var item = await _context.Vehicles
            .FirstOrDefaultAsync(x => x.Id == vehicleId);

        if (item is not null)
        {
            _context.Vehicles.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}