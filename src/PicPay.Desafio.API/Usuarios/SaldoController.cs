using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PicPay.Desafio.API.Usuarios.Models;
using PicPay.Desafio.Application.Usuarios;

namespace PicPay.Desafio.API.Usuarios
{
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
        public IActionResult ObterSaldo()
        {
            var idUsuarioClaim = User.FindFirst("sub")!.Value;
            var saldoResult = _usuarioService.ObterSaldo(int.Parse(idUsuarioClaim));

            if (saldoResult.IsFailed)
                return Problem(saldoResult.Errors.First().Message);

            var saldoUsuario = saldoResult.Value;
            var response = new SaldoResponse
            {
                Mensagem = $"Saldo atual em {DateTime.Now}",
                Saldo = saldoUsuario.Quantia,
                Moeda = saldoUsuario.Moeda
            };

            return Ok(response);
        }
    }
}
