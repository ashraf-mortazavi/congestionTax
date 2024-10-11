using congestionTax.Components.Models;

namespace congestionTax.Components.Services.TaxRuleService;

public interface ITaxRuleService
{
    Task<List<TaxPeriod>> GetTaxPeriodRulesAsync(int cityId);
    Task AddOrUpdateTaxPeriodRuleAsync(TaxPeriod taxPeriod);
    Task RemoveTaxPeriodRuleAsync(int taxPeriodId);
}