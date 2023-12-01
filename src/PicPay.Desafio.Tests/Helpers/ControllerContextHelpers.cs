using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PicPay.Desafio.Tests.Helpers
{
    public static class ControllerContextHelpers
    {
        public static ClaimsPrincipal CriarUsuarioAutenticado()
        {
            return new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new(JwtRegisteredClaimNames.Sub, "1"),
            new(JwtRegisteredClaimNames.Email, "fulano@fulano.com"),
        }, "mock"));
        }

        public static ControllerContext CriarContextMock()
        {
            var usuarioAutenticadoMock = CriarUsuarioAutenticado();
            return CriarContextMock(usuarioAutenticadoMock);
        }

        public static ControllerContext CriarContextMock(ClaimsPrincipal usuarioAutenticadoMock)
        {
            return new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = usuarioAutenticadoMock }
            };
        }
    }
}
