using Microsoft.Extensions.DependencyInjection;
using PicPay.Desafio.Application.Usuarios;

namespace PicPay.Desafio.Infra.Usuarios
{
    public static class UsuarioDIConfiguration
    {
        public static IServiceCollection ConfigurarUsuarioServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
