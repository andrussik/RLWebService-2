using System;
using System.Net.Http.Headers;
using BackgroundTasks;
using BLL.Extensions;
using DAL.Extensions;
using IdentityServerClient.Extensions;
using IdentityServerClient.TokenHandlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Startup>()
                .Build();
            
            services.AddHostedService<TimedHostedService>();
            services.AddIdentityServerClients();
            services.AddDal(configuration);
            services.AddBll();
            services.AddHttpClient("Sierra",
                    c => { c.BaseAddress = new Uri(configuration["HttpClients:Sierra:Url"]); })
                .AddHttpMessageHandler<SierraTokenHandler>();

            // services.AddHttpClient("Riks", 
            //         c => { c.BaseAddress = new Uri(configuration["HttpClients:Riks:Url"]); })
            //     .AddHttpMessageHandler<RiksTokenHandler>();
            //
            // services.AddHttpClient("Urram", 
            //         c => { c.BaseAddress = new Uri(configuration["HttpClients:Urram:Url"]); })
            //     .AddHttpMessageHandler<UrramTokenHandler>();

            services.AddHttpClient("SierraToken", c =>
            {
                var authenticationScheme = configuration["HttpClients:SierraToken:AuthenticationScheme"];
                var token = configuration["ApiKeys:SierraApiKey"];
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authenticationScheme, token);
                c.BaseAddress = new Uri(configuration["HttpClients:SierraToken:Url"]);
            });

            // services.AddHttpClient("RiksToken", c =>
            // {
            //     var authenticationScheme = configuration["HttpClients:RiksToken:AuthenticationScheme"];
            //     var token = configuration["ApiKeys:RiksApiKey"];
            //     c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authenticationScheme, token);
            //     c.BaseAddress = new Uri(configuration["HttpClients:RiksToken:Url"]);
            // });
            //
            // services.AddHttpClient("urramToken", c =>
            // {
            //     var authenticationScheme = configuration["HttpClients:UrramToken:AuthenticationScheme"];
            //     var token = configuration["ApiKeys:UrramApiKey"];
            //     c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authenticationScheme, token);
            //     c.BaseAddress = new Uri(configuration["HttpClients:UrramToken:Url"]);
            // });
            services.AddSingleton<IElasticClient, ElasticClient>();
        }
    }
}