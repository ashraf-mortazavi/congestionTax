using congestionTax.Components.Models;

namespace congestionTax.Components.Services.CityService;

public interface ICityService
{
    Task<List<City>> GetCitiesAsync();
    Task AddOrUpdateCityAsync(City city);
    Task RemoveCityAsync(int cityId);
}