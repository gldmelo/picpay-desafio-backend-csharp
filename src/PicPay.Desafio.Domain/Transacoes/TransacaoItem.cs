using PicPay.Desafio.Domain.ValueObjects;
using static PicPay.Desafio.Domain.Transacoes.Transacao;

namespace PicPay.Desafio.Domain.Transacoes
{
    public class TransacaoItem
    {
        public int IdUsuario { get; }
        public DateTime DataTransacao { get; }
        public bool IsLancamentoCredito { get; }
        public TipoLancamentoExtrato TipoLancamento { get; }
        public Dinheiro Quantia { get; }

        private TransacaoItem(int idUsuario, DateTime dataTransacao, bool isLancamentoCredito, TipoLancamentoExtrato tipoLancamento, Dinheiro quantia)
        {
            IdUsuario = idUsuario;
            DataTransacao = dataTransacao;
            IsLancamentoCredito = isLancamentoCredito;
            TipoLancamento = tipoLancamento;
            Quantia = quantia;
        }

        public static TransacaoItem OperacaoEnviarDinheiro(int idUsuario, DateTime dataTransacao, Dinheiro quantia)
        {
            return new TransacaoItem(idUsuario, dataTransacao, false, TipoLancamentoExtrato.Envio, quantia);
        }

        public static TransacaoItem OperacaoReceberDinheiro(int idUsuario, DateTime dataTransacao, Dinheiro quantia)
        {
            return new TransacaoItem(idUsuario, dataTransacao, true, TipoLancamentoExtrato.Recebimento, quantia);
        }
    }
}
