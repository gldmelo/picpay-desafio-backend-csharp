using FluentResults;

namespace PicPay.Desafio.Application.Transacoes
{
    public interface ITransacaoService
    {
        Result EnviarDinheiro(TransacaoDto transacao);
    }
}
