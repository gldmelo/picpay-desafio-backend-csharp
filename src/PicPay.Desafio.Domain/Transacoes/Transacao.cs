using FluentResults;
using PicPay.Desafio.Domain.Usuarios;
using PicPay.Desafio.Domain.ValueObjects;

namespace PicPay.Desafio.Domain.Transacoes
{
    /// <summary>
    /// Aggregate-Root de Transações
    /// </summary>
    public class Transacao
    {
        readonly ITransacaoRepository _transacaoRepository;

        public enum TipoLancamentoExtrato
        {
            Deposito = 1,
            Saque = 2,
            Envio = 3,
            Recebimento = 4,
            Estorno = 5
        }

        public Transacao(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }
        
        public Result EnviarDinheiro(Usuario remetente, Usuario destinatario, Dinheiro quantiaATransferir)
        {
            if (remetente.Saldo < quantiaATransferir)
                return Result.Fail("Saldo insuficiente.");

            if (remetente is UsuarioLojista)
                return Result.Fail("Lojistas não podem enviar dinheiro para outras carteiras.");

            var dataOperacao = DateTime.Now;
            var operacoes = new List<TransacaoItem>
            {
                TransacaoItem.OperacaoEnviarDinheiro(remetente.Id, dataOperacao, quantiaATransferir),
                TransacaoItem.OperacaoReceberDinheiro(destinatario.Id, dataOperacao, quantiaATransferir)
            };

            return _transacaoRepository.RegistrarTransacao(operacoes);
        }

        public Result DepositarDinheiro(Usuario usuarioDepositante, Dinheiro dinheiroADepositar)
        {
            if (dinheiroADepositar.Quantia <= 0)
                return Result.Fail("A quantia a depositar deve ser um valor positivo maior que zero.");

            if (dinheiroADepositar.Moeda != "BRL")
                return Result.Fail("Só são aceitos depósitos em reais.");

            var dataOperacao = DateTime.Now;
            var operacoes = new List<TransacaoItem>
            {
                TransacaoItem.OperacaoDepositarDinheiro(usuarioDepositante.Id, dataOperacao, dinheiroADepositar),
            };

            return _transacaoRepository.RegistrarTransacao(operacoes);
        }
    }
}
