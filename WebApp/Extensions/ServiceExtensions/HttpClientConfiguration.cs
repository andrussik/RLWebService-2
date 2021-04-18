using System;
using System.Net.Http.Headers;
using IdentityServerClient.TokenHandlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace WebApp.Extensions.ServiceExtensions
{
    public static class HttpClientConfiguration
    {
        public static IServiceCollection AddHttpClients(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddHttpClient("Sierra",
                    c => { c.BaseAddress = new Uri(configuration["HttpClients:Sierra:Url"]); })
                .AddHttpMessageHandler<SierraTokenHandler>();

            services.AddHttpClient("Riks", 
                    c => { c.BaseAddress = new Uri(configuration["HttpClients:Riks:Url"]); })
                .AddHttpMessageHandler<RiksTokenHandler>();

            services.AddHttpClient("Urram", 
                    c => { c.BaseAddress = new Uri(configuration["HttpClients:Urram:Url"]); })
                .AddHttpMessageHandler<UrramTokenHandler>();

            services.AddHttpClient("SierraToken", c =>
            {
                var authenticationScheme = configuration["HttpClients:SierraToken:AuthenticationScheme"];
                var token = configuration["ApiKeys:SierraApiKey"];
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authenticationScheme, token);
                c.BaseAddress = new Uri(configuration["HttpClients:SierraToken:Url"]);
            });

            services.AddHttpClient("RiksToken", c =>
            {
                var authenticationScheme = configuration["HttpClients:RiksToken:AuthenticationScheme"];
                var token = configuration["ApiKeys:RiksApiKey"];
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authenticationScheme, token);
                c.BaseAddress = new Uri(configuration["HttpClients:RiksToken:Url"]);
            });

            services.AddHttpClient("urramToken", c =>
            {
                var authenticationScheme = configuration["HttpClients:UrramToken:AuthenticationScheme"];
                var token = configuration["ApiKeys:UrramApiKey"];
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authenticationScheme, token);
                c.BaseAddress = new Uri(configuration["HttpClients:UrramToken:Url"]);
            });
            
            return services;
        }
    }
}