using Microsoft.Extensions.DependencyInjection;
using PicPay.Desafio.Application.Services.Usuario;
using PicPay.Desafio.Infra.Models;

namespace PicPay.Desafio.Infra.Usuario
{
    public static class UsuarioDIConfiguration
    {
        public static IServiceCollection ConfigurarUsuarioServices(this IServiceCollection services)
        {
            services.AddDbContext<PicPayContext>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
