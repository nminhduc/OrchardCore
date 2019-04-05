using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.HomeRoute.Routing;
using OrchardCore.Modules;

namespace OrchardCore.HomeRoute
{
    public class Startup : StartupBase
    {
        public override int Order => -500;

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<HomePageRoute>();
            services.AddSingleton<IEndpointAddressScheme<RouteValuesAddress>, HomeRouteValuesAddressScheme>();
        }

        public override void Configure(IApplicationBuilder app, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            app.UseMiddleware<HomeRouteMiddleware>();
        }
    }
}
