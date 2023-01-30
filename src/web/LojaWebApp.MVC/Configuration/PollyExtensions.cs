using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace LojaWebApp.MVC.Configuration
{
    public class PollyExtensions
    {
        public static AsyncRetryPolicy<HttpResponseMessage> EsperarERetentar()
        {
            var retryPolicy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(new[]
            {
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(7),
            }, (outcome, timeSpan, retryCount, context) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Tentando pela {retryCount} vez!");
                Console.ForegroundColor = ConsoleColor.White;
            });

            return retryPolicy;
        }
    }
}

