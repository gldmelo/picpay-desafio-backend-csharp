using PicPay.Desafio.Domain.ValueObjects;

namespace PicPay.Desafio.Application.Usuarios
{
    public interface IUsuarioRepository
    {
        int ObterIdUsuarioByEmail(string emailUsuario);
        UsuarioDto ObterUsuarioById(int idUsuario);
        UsuarioDto ObterUsuarioByEmail(string emailUsuario);

        Dinheiro ObterSaldo(int idUsuario);
    }
}
