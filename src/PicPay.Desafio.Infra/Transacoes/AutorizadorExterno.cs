using FluentResults;
using PicPay.Desafio.Application.Transacoes;

namespace PicPay.Desafio.Infra.Transacoes
{
    public class AutorizadorExterno : IAutorizadorExterno
    {
        public Result AutorizarTransacao(TransacaoDto transacao)
        {
            // Simula a execução da chamada a um serviço externo para validação da transação

            return Result.Ok();
        }
    }
}
