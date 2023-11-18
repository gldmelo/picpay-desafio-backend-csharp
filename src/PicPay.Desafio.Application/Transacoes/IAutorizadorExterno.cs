using FluentResults;

namespace PicPay.Desafio.Application.Transacoes
{
    public interface IAutorizadorExterno
    {
        Result AutorizarTransacao(TransacaoDto transacao);
    }
}
