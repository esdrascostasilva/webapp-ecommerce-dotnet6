using LojaWebApp.MVC.Extensions;
using LojaWebApp.MVC.Services;
using LojaWebApp.MVC.Services.Handlers;

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
                .AddPolicyHandler(PollyExtensions.EsperarERetentar());
               
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUser, AspNetUser>();

        }
    }
}