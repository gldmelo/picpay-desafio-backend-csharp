using PicPay.Desafio.Domain.ValueObjects;

namespace PicPay.Desafio.Application.Services.Usuario
{
    public interface IUsuarioRepository
    {
        Domain.Entidades.Usuario ObterUsuarioByEmail(string emailUsuario);

        //Dinheiro ObterSaldo(int idUsuario);
    }
}
