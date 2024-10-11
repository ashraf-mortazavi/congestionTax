using congestionTax.Components;
using congestionTax.Components.Data;
using congestionTax.Components.Services;
using congestionTax.Components.Services.CityService;
using congestionTax.Components.Services.CongestionTaxCalculator;
using congestionTax.Components.Services.HolidayService;
using congestionTax.Components.Services.TaxRuleService;
using congestionTax.Components.Services.VehiclesService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<CongestionTaxDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SvcDbContext")));

Console.WriteLine($"Environment:{builder.Environment.EnvironmentName}");
Console.WriteLine($"Connectionstring:{builder.Configuration.GetConnectionString("SvcDbContext")}");
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICongestionTaxCalculatorService, CongestionTaxCalculatorService>();
builder.Services.AddScoped<IHolidayService, HolidayService>();
builder.Services.AddScoped<ITaxRuleService, TaxRuleService>();
builder.Services.AddScoped<IVehiclesService, VehiclesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();