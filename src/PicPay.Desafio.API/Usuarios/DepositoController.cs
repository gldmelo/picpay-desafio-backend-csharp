using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PicPay.Desafio.API.Usuarios.Models;
using PicPay.Desafio.Application.Transacoes;

namespace PicPay.Desafio.API.Usuarios
{
    public class DepositoController : ControllerBase
    {
        readonly ITransacaoService _transacaoService;

        public DepositoController(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        /// <summary>
        /// Permite realizar um depósito na conta do usuário
        /// </summary>
        [Route("usuario/deposito")]
        [Produces("application/json")]
        [HttpPut]
        [Authorize]
        public IActionResult RealizarDeposito([FromBody] DepositoRequest req)
        {
            var idUsuarioClaim = int.Parse(User.FindFirst("sub")!.Value);
            var transacaoDto = new TransacaoDto { IdRemetente = idUsuarioClaim, Quantia = req.Quantia, Moeda = req.Moeda };

            var depositoResult = _transacaoService.DepositarDinheiro(transacaoDto);

            var mensagemRetorno = depositoResult.IsSuccess
                        ? $"Seu depósito de {req.Quantia} {req.Moeda} foi recebido!"
                        : depositoResult.Errors.First().Message;

            return Ok(new DepositoResponse { Mensagem = mensagemRetorno });
        }
    }
}
