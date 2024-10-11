using congestionTax.Components.Data;
using congestionTax.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace congestionTax.Components.Services.HolidayService;

public class HolidayService(CongestionTaxDbContext dbContext) : IHolidayService
{
    private readonly CongestionTaxDbContext _dbcontext = dbContext;

    public async Task<List<Holiday>> GetHolidaysAsync(int cityId)
    {
        return await _dbcontext.Holidays
            .Where(x => x.CityId == cityId)
            .ToListAsync();
    }

    public async Task AddOrUpdateHolidayAsync(Holiday holiday)
    {
        var item = await _dbcontext.Holidays
            .FirstOrDefaultAsync(x => x.Id ==holiday.Id);

        if (item is null)
            _dbcontext.Holidays.Add(holiday);
        else
            _dbcontext.Holidays.Update(holiday);

        await _dbcontext.SaveChangesAsync();
    }

    public async Task RemoveHolidayAsync(int holidayId)
    {
        var item = await _dbcontext.Holidays
            .FirstOrDefaultAsync(x => x.Id == holidayId);

        if (item is not null)
        {
            _dbcontext.Holidays.Remove(item);
            await _dbcontext.SaveChangesAsync();
        }
    }
}