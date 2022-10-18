using System;
using LojaWebApp.MVC.Services;

namespace LojaWebApp.MVC.Configuration
{
    public static class DIConfig
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddHttpClient<IAutenticationService, AutenticationService>();
        }
    }
}

