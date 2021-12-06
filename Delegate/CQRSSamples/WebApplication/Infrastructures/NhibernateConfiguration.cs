using Microsoft.Extensions.DependencyInjection;
using WebApplication.Application.Interfaces;
using WebApplication.Application.Repositories;
using WebApplication.Infrastructures.Data.NhibernateRepository;
using WebApplication.Infrastructures.Data.Read;

namespace WebApplication.Infrastructures
{
    public static class NhibernateConfiguration
    {
        public static void AddDataLayerService(
            this IServiceCollection services,
            string connectionString)
        {
            ConfigWriteSide(services, connectionString);
            ConfigReadSide(services, connectionString);
        }

        private static void ConfigReadSide(IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IReadDbConnectionFactory>(new SqliteReadDbConnectionFactory(connectionString));
        }

        private static void ConfigWriteSide(IServiceCollection services, string connectionString)
        {
            services.AddSingleton(new NhibernateConnectionMgr(connectionString));
            services.AddScoped(mgr => mgr.GetService<NhibernateConnectionMgr>()
                ?.CreateSession());
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}