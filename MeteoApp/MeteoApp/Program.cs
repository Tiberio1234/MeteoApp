using MeteoApp.Components;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); // Add server-side interactive component support
builder.Services.AddSingleton<ThemeService>();
builder.Services.AddRadzenComponents();
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
