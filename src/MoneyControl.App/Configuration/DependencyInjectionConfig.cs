using MoneyControl.Business.Interfaces;
using MoneyControl.Business.Interfaces.Repository;
using MoneyControl.Business.Notifications;
using MoneyControl.Business.Services;
using MoneyControl.Data.Context;
using MoneyControl.Data.Repository;

namespace MoneyControl.App.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MoneyControlDbContext>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<ITransactionService, TransactionService>();

            return services;
        }
    }
}
