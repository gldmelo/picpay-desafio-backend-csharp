using PicPay.Desafio.Domain.ValueObjects;

namespace PicPay.Desafio.Application.Usuarios
{
    public interface IUsuarioRepository
    {
        int ObterIdUsuarioByEmail(string emailUsuario);
        UsuarioDto ObterUsuarioByEmail(string emailUsuario);

        Dinheiro ObterSaldo(int idUsuario);
    }
}
