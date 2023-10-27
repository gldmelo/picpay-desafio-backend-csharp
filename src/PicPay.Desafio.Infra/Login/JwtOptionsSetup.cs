using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PicPay.Desafio.Infra.Login
{
    public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
    {
        public static string SectionName = "Jwt";
        private readonly IConfiguration _configuration;

        public JwtOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(JwtOptions options)
        {
            _configuration.GetSection(SectionName).Bind(options);
        }
    }
}
