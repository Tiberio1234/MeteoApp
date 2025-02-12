using MeteoApp.Components;
using MeteoApp.Components.Services;
using MeteoApp.Components.ViewModels;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

// Register HttpClient and WeatherService
builder.Services.AddHttpClient<WeatherDataService>();
builder.Services.AddScoped<WeatherDataService>();

// Register other services
builder.Services.AddRadzenComponents();
builder.Services.AddSingleton<AnalyticsViewModel>();
builder.Services.AddSingleton<ThemeService>();
builder.Services.AddScoped<WeatherViewModel>();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts(); // Add HSTS for production
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Map the Razor components and set the render mode to InteractiveServerRenderMode
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();  // Add this to enable Interactive server render mode

app.Run();
