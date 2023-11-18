using Microsoft.Extensions.DependencyInjection;
using PicPay.Desafio.Application.Transacoes;
using PicPay.Desafio.Domain.Transacoes;

namespace PicPay.Desafio.Infra.Transacoes
{
    public static class TransacaoDIConfiguration
    {
        public static IServiceCollection ConfigurarTransacaoServices(this IServiceCollection services)
        {
            services.AddScoped<Transacao, Transacao>();
            services.AddScoped<ITransacaoService, TransacaoService>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            services.AddScoped<IAutorizadorExterno, AutorizadorExterno>();

            return services;
        }
    }
}
