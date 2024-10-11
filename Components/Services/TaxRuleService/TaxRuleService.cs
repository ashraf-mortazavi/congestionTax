using congestionTax.Components.Data;
using congestionTax.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace congestionTax.Components.Services.TaxRuleService;

public class TaxRuleService(CongestionTaxDbContext context) : ITaxRuleService
{
    private readonly CongestionTaxDbContext _context = context;
    
    public async Task<List<TaxPeriod>> GetTaxPeriodRulesAsync(int cityId)
    {
        return await _context.TaxPeriods
            .Where(x => x.CityId == cityId)
            .ToListAsync();
    }

    public async Task AddOrUpdateTaxPeriodRuleAsync(TaxPeriod taxPeriod)
    {
        var item = await _context.TaxPeriods
            .FirstOrDefaultAsync(x => x.Id == taxPeriod.Id);

        if (item is null)
            _context.TaxPeriods.Add(taxPeriod);
        else
            _context.TaxPeriods.Update(taxPeriod);

        await _context.SaveChangesAsync();
    }

    public async Task RemoveTaxPeriodRuleAsync(int taxPeriodId)
    {
        var item = await _context.TaxPeriods
            .FirstOrDefaultAsync(x => x.Id == taxPeriodId);

        if (item is not null)
        {
            _context.TaxPeriods.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}