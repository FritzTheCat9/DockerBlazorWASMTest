using DockerBlazorWASMTest.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var backendUrl = builder.Configuration.GetValue<string>("BackendUrl");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(backendUrl) });

await builder.Build().RunAsync();
