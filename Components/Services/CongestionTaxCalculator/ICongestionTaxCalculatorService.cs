namespace congestionTax.Components.Services;

public interface ICongestionTaxCalculatorService
{
    Task<int> CalculateTaxAsync(int cityId, List<DateTime> passageTimes, string vehicleType);
}