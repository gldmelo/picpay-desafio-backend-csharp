using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PicPay.Desafio.API.Usuarios.Models;
using PicPay.Desafio.Application.Transacoes;

namespace PicPay.Desafio.API.Usuarios
{
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _transacaoService;

        public TransacaoController(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        [Route("usuario/transaction")]
        [Produces("application/json")]
        [HttpGet]
        [Authorize]
        public IActionResult EnviarDinheiro([FromBody] TransacaoRequest req)
        {
            var idUsuarioClaim = int.Parse(User.FindFirst("sub")!.Value);
            var transacaoDto = new TransacaoDto { IdRemetente = idUsuarioClaim, EmailDestinatario = req.EmailDestinatario, Quantia = req.Quantia, Moeda = req.Moeda };

            var transacaoResult = _transacaoService.EnviarDinheiro(transacaoDto);

            if (transacaoResult.IsFailed)
                return Problem(transacaoResult.Errors.First().Message);

            var mensagemRetorno = transacaoResult.IsSuccess
                        ? "Você enviou dinheiro"
                        : transacaoResult.Errors.First().Message;

            return Ok(new DepositoResponse { Mensagem = mensagemRetorno });
        }
    }
}
