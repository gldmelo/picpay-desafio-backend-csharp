
namespace PicPay.Desafio.Domain.ValueObjects
{
    public class Carteira
    {
        readonly Dinheiro _saldo;
        public Carteira(Dinheiro saldoInicial)
        {
            _saldo = saldoInicial;
        }

        public Dinheiro Saldo => _saldo;
    }
}
