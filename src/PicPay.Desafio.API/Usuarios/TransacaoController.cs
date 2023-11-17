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
        public IActionResult EnviarDinheiro([FromHeader] TransacaoRequest req)
        {
            var idUsuarioClaim = int.Parse(User.FindFirst("sub")!.Value);
            var transacaoDto = new TransacaoDto { IdRemetente = idUsuarioClaim, EmailDestinatario = req.EmailDestinatario, Quantia = req.Quantia, Moeda = req.Moeda };

            // criar projeto p/ Mock de autorizaçdão
            // criar projeto p/ Mock de envio de notificação
            _transacaoService.EnviarDinheiro(transacaoDto);
            
            var response = new TransacaoResponse
            {
                Status = "Você enviou dinheiro"
            };

            return Ok();
        }
    }
}
