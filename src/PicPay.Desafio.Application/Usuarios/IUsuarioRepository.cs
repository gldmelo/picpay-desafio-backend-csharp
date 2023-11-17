using PicPay.Desafio.Domain.ValueObjects;

namespace PicPay.Desafio.Application.Usuarios
{
    public interface IUsuarioRepository
    {
        UsuarioDto ObterUsuarioByEmail(string emailUsuario);

        Dinheiro ObterSaldo(int idUsuario);
    }
}
