using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.SessionStorage;
using Blazored.Toast;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NegueApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Fluxor
builder.Services.AddFluxor(options =>
{
    options
        .ScanAssemblies(typeof(Program).Assembly)
        .UseReduxDevTools();
});

// modal
builder.Services.AddBlazoredModal();

// notifications
builder.Services.AddBlazoredToast();

// Persistence dans le localStorage / sessionStorage
builder.Services.AddBlazoredLocalStorage(config =>
{
    config.JsonSerializerOptions.WriteIndented = true;
});
builder.Services.AddBlazoredSessionStorage(config =>
{
    config.JsonSerializerOptions.WriteIndented = true;
});


RegisterApiServices(builder.Services);

await builder.Build().RunAsync();


static void RegisterApiServices(IServiceCollection services)
{ 
}