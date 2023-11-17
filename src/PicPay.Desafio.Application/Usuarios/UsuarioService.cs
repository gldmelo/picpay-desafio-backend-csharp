using PicPay.Desafio.Domain.ValueObjects;

namespace PicPay.Desafio.Application.Usuarios
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
            var usuarioDto = _usuarioRepository.ObterUsuarioByEmail(emailUsuario);
            var saldo = _usuarioRepository.ObterSaldo(usuarioDto.Id);

            return saldo;
        }

    }
}
