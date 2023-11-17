using Microsoft.Extensions.DependencyInjection;
using PicPay.Desafio.Application.Transacoes;

namespace PicPay.Desafio.Infra.Transacoes
{
    public static class TransacaoDIConfiguration
    {
        public static IServiceCollection ConfigurarTransacaoServices(this IServiceCollection services)
        {
            services.AddScoped<ITransacaoService, TransacaoService>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();

            return services;
        }
    }
}
