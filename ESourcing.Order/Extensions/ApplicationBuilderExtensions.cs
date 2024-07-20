using ESourcing.Order.Consumers;
using Microsoft.Extensions.DependencyInjection;

namespace ESourcing.Order.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static EventBusOrderCreateConsumer Listener { get; set; }

        public static IApplicationBuilder UseEventBusListener(this IApplicationBuilder app) 
        {
            Listener = app.ApplicationServices.GetService<EventBusOrderCreateConsumer>();

            var lifeTimeScope = app.ApplicationServices.GetService<IHostApplicationLifetime>();
            lifeTimeScope.ApplicationStarted.Register(OnStarted);
            lifeTimeScope.ApplicationStopping.Register(OnStopping);

            return app;
        }

        private static void OnStarted()
        {
            Listener.Consume();
        }

        private static void OnStopping()
        {
            Listener.Disconnect();
        }

    }
}
