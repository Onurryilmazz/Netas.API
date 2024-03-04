using Banking.Application.Interfaces.Repositories;
using Banking.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Banking.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        #region Repositories
        services.AddScoped<ILogRepository, LogRepository>();
        services.AddScoped<IBankRepository, BankRepository>();
        services.AddScoped<IStatuRepository, StatuRepository>();
        services.AddScoped<ITransactionDetailRepository, TransactionDetailRepository>();
        services.AddScoped<ITransactionTypeRepository, ITransactionTypeRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        #endregion

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}