using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace PicPay.Desafio.Infra.Login
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;

        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public string GerarTokenJwt(string email)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "10"), // ID usuário
                new Claim(JwtRegisteredClaimNames.Email, email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
            var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // tempo de expiração do token: 1 hora
            var expiration = DateTime.UtcNow.AddHours(1);
            var token = new JwtSecurityToken(
               issuer: _options.Issuer,
               audience: _options.Audience,
               claims: claims,
               expires: expiration,
               signingCredentials: credenciais);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
