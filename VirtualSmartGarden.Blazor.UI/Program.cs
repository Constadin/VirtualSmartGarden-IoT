using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VirtualSmartGarden.Blazor.UI;
using VirtualSmartGarden.Blazor.UI.ServiceCollectionRegistrationDI;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5134/")
});
builder.Services.RegisterBlazorUIServices();

await builder.Build().RunAsync();
