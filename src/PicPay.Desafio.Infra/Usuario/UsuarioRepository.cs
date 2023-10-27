using PicPay.Desafio.Application.Services.Usuario;
using PicPay.Desafio.Domain.ValueObjects;
using PicPay.Desafio.Infra.Models;

namespace PicPay.Desafio.Infra.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {
        PicPayContext _dbContext { get; }

        public UsuarioRepository(PicPayContext context)
        {
            _dbContext = context;
        }

        public Domain.Entidades.Usuario ObterUsuarioByEmail(string emailUsuario)
        {
            var usuarioEf = _dbContext.Usuarios.First(x => x.Email.Equals(emailUsuario));
            var saldoInicial = ObterSaldo(usuarioEf.IdUsuario);
            return usuarioEf.ConvertToDomain(saldoInicial);
        }

        private Dinheiro ObterSaldo(int idUsuario)
        {
            var saldo = _dbContext.Transacoes.Where(x => x.Moeda == "BRL" && x.IdUsuario == idUsuario && x.TipoOperacao == false).Sum(x => x.Quantia)
                - _dbContext.Transacoes.Where(x => x.Moeda == "BRL" && x.IdUsuario == idUsuario && x.TipoOperacao == true).Sum(x => x.Quantia);

            return new Dinheiro(saldo, "BRL");
        }
    }
}
