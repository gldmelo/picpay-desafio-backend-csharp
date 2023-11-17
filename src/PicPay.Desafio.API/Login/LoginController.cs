using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PicPay.Desafio.Infra.Login;

namespace PicPay.Desafio.API.Login
{
    public class LoginController : ControllerBase
    {
        readonly IJwtProvider _jwtTokenProvider;

        public LoginController(IJwtProvider jwtTokenProvider)
        {
            _jwtTokenProvider = jwtTokenProvider;
        }

        [Route("login")]
        [Produces("application/json")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Autenticar([FromBody] LoginModel model)
        {
            bool isLoginValido = model.Email == "fulano@email.com";

            if (!isLoginValido)
                return BadRequest();

            var token = _jwtTokenProvider.GerarTokenJwt(model.Email);
            return Ok(token);
        }
    }
}
