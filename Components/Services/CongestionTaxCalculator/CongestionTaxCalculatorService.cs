using congestionTax.Components.Data;
using congestionTax.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace congestionTax.Components.Services.CongestionTaxCalculator;

public class CongestionTaxCalculatorService (CongestionTaxDbContext dbContext) : ICongestionTaxCalculatorService
{
    private readonly CongestionTaxDbContext _dbContext = dbContext;
    
    public async Task<int> CalculateTaxAsync(int cityId, List<DateTime> passageTimes, string vehicleType)
    {
        var city = await _dbContext.Cities
            .Include(x => x.TaxPeriods)
            .Include(x => x.Holidays)
            .Include(x => x.Vehicles)
            .FirstOrDefaultAsync(c => c.Id == cityId);
        if (city is null || city.Vehicles.Any(x => x.VehicleType.ToString() == vehicleType))
            return 0;
        
        DateTime? lastPassageTime = null;
        int highestTax = 0;
        int totalTax = 0;
        
        foreach (var passageTime in passageTimes)
        {
            if (city.Holidays.Any(c => c.HolidayDate.Date == passageTime.Date))
                continue;
            
            if (passageTime.Month == 7 ||
                passageTime.DayOfWeek == DayOfWeek.Saturday ||
                passageTime.DayOfWeek == DayOfWeek.Sunday)
                continue;
            
            if (lastPassageTime.HasValue &&
                (passageTime - lastPassageTime.Value).TotalMinutes < 60)
            {
                highestTax = Math.Max(highestTax, GetCongestionTaxByTime(city, passageTime));
            }

            else
            {
                highestTax = GetCongestionTaxByTime(city, passageTime);
                lastPassageTime = passageTime;
            }

            totalTax += highestTax;

        }

        return totalTax > city.MaxDailyTax ? city.MaxDailyTax : totalTax;
    }

    private int GetCongestionTaxByTime(City city, DateTime passageTime)
    {
        var taxPeriod = city.TaxPeriods
            .FirstOrDefault(x => passageTime.TimeOfDay >= x.StartTime &&
                                 passageTime.TimeOfDay <= x.EndTime);
        
        return taxPeriod?.Amount ?? 0;
    }
}