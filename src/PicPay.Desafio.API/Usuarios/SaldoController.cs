using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PicPay.Desafio.Application.Usuarios;

namespace PicPay.Desafio.API.Usuarios
{
    [Authorize]
    public class SaldoController : ControllerBase
    {
        IUsuarioService _usuarioService;

        public SaldoController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [Route("usuario/saldo")]
        [Produces("application/json")]
        [HttpGet]
        [Authorize]
        public IActionResult ObterSaldo([FromHeader] SaldoRequest req)
        {
            var saldoUsuario = _usuarioService.ObterSaldo(req.Email);

            var response = new SaldoResponse
            {
                Saldo = saldoUsuario.Quantia,
                Moeda = saldoUsuario.Moeda
            };

            return Ok(response);
        }
    }
}
