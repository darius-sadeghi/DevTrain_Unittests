using BUnitTest.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BUnitTest.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddScoped<IPersonService, PersonService>();

            await builder.Build().RunAsync();
        }
    }
}
