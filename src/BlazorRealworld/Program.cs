using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlazorRealworld
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(configure =>
            {
                configure.Add(ServiceDescriptor.Singleton<AppState, AppState>());
                configure.Add(ServiceDescriptor.Singleton<ApiClient, ApiClient>());
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }
    }
}
