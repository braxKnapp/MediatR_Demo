using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MediatR;
using BlazorMediatorDemo.Core.Services;
using MatBlazor;

namespace BlazorMediatorDemo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<ICacheManager, CacheManager>();
            //This is how you add the MediatR service to the program
            builder.Services.AddMediatR(typeof(Program));
            builder.Services.AddMatBlazor();

            await builder.Build().RunAsync();
        }
    }
}
