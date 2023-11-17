using PicPay.Desafio.Domain.Usuarios;
using PicPay.Desafio.Domain.ValueObjects;

namespace PicPay.Desafio.Application.Usuarios
{
    public static class UsuarioDtoMapper
    {
        public static Domain.Usuarios.Usuario ConvertToDomain(this UsuarioDto usuarioDto, Dinheiro saldo)
        {
            Domain.Usuarios.Usuario usuario = usuarioDto.Tipo switch
            {
                "PF" => new UsuarioComum(usuarioDto.Id, usuarioDto.NomeCompleto,
                        new Email(usuarioDto.Email),
                        new Cpf(usuarioDto.Documento), saldo),

                "PJ" => new UsuarioLojista(usuarioDto.Id, usuarioDto.NomeCompleto,
                        new Email(usuarioDto.Email),
                        new Cnpj(usuarioDto.Documento), saldo),

                _ => throw new Exception("Tipo de Usuário inválido!")
            };

            return usuario;
        }
    }
}
