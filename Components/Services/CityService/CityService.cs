using congestionTax.Components.Data;
using congestionTax.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace congestionTax.Components.Services.CityService;

public class CityService(CongestionTaxDbContext context) : ICityService
{
    private readonly CongestionTaxDbContext _context = context;
    
    public async Task<List<City>> GetCitiesAsync()
    {
        return await _context.Cities.ToListAsync();
    }

    public async Task AddOrUpdateCityAsync(City city)
    {
        var item = await _context.Cities.FirstOrDefaultAsync(x => x.Name == city.Name);
        if (item is null)
        {
             _context.Cities.Add(city);
        }
        else
        {
            _context.Cities.Update(city);
        }

        await _context.SaveChangesAsync();
    }

    public async Task RemoveCityAsync(int cityId)
    {
        var item = await _context.Cities.FirstOrDefaultAsync(x => x.Id == cityId);
        if (item is not null)
        {
            _context.Cities.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}