
namespace PicPay.Desafio.Application.Transacoes
{
    public interface ITransacaoService
    {
        void EnviarDinheiro(TransacaoDto transacao);
    }
}
