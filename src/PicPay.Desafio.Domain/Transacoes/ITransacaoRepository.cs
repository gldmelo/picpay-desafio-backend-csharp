using FluentResults;

namespace PicPay.Desafio.Domain.Transacoes
{
    public interface ITransacaoRepository
    {
        Result RegistrarTransacao(List<TransacaoItem> operacoes);

        //Result Estorno();
    }
}
