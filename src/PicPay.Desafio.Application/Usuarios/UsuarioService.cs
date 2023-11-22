using FluentResults;
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

        public Result<Dinheiro> ObterSaldo(int idUsuario)
        {
            var saldo = _usuarioRepository.ObterSaldo(idUsuario);
            return Result.Ok(saldo);
        }
    }
}
