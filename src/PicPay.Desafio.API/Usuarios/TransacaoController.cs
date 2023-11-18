using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

            var resultado = _transacaoService.EnviarDinheiro(transacaoDto);
            
            var response = new TransacaoResponse
            {
                Status = resultado.IsSuccess ? "Você enviou dinheiro" : resultado.Errors[0].Message,
            };

            return Ok();
        }
    }
}
