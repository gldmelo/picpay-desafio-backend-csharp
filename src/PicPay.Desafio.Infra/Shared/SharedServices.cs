using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PicPay.Desafio.Infra.Shared
{
    public static class SharedServices
    {
        public static IServiceCollection ConfigurarBancoDados(this IServiceCollection services)
        {
            services.AddSingleton(serviceProvider =>
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("sqlserver") ?? throw new ApplicationException("Connection String não foi informada");
                return new SqlConnectionFactory(connectionString);
            });

            return services;
        }
    }
}
