using LojaWebApp.MVC.Extensions;
using LojaWebApp.MVC.Services;
using LojaWebApp.MVC.Services.Handlers;
using Polly;

namespace LojaWebApp.MVC.Configuration
{
    public static class DIConfig
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IAutenticationService, AutenticationService>();

            services.AddHttpClient<ICatalogoService, CatalogoService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                .AddPolicyHandler(PollyExtensions.EsperarERetentar())
                .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(15)));
               
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUser, AspNetUser>();

        }
    }
}