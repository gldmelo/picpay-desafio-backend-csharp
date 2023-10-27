using PicPay.Desafio.Domain.ValueObjects;

namespace PicPay.Desafio.Application.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        public IUsuarioRepository _usuarioRepository { get; }

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Dinheiro ObterSaldo(string emailUsuario)
        {
            var usuario = _usuarioRepository.ObterUsuarioByEmail(emailUsuario);
            return usuario.Saldo;
        }
        
    }
}
