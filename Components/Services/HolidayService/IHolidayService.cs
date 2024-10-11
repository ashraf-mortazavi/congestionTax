using congestionTax.Components.Models;

namespace congestionTax.Components.Services.HolidayService;

public interface IHolidayService
{
    Task<List<Holiday>> GetHolidaysAsync(int cityId);
    Task AddOrUpdateHolidayAsync(Holiday holiday);
    Task RemoveHolidayAsync(int holidayId);
}