using PicPay.Desafio.Domain.Entidades;
using PicPay.Desafio.Domain.ValueObjects;

namespace PicPay.Desafio.Infra.Usuario
{
    public static class UsuarioMapper
    {
        /// <summary>
        /// Converte um objeto usuário do banco de dados em um objeto Usuario do domínio
        /// </summary>
        public static Domain.Entidades.Usuario ConvertToDomain(this Infra.Models.Usuario usuarioef, Dinheiro saldoUsuario)
        {
            Domain.Entidades.Usuario usuario = usuarioef.Tipo switch
            {
                "PF" => new UsuarioComum(usuarioef.IdUsuario, usuarioef.NomeCompleto,
                        new Email(usuarioef.Email),
                        new Cpf(usuarioef.Documento), saldoUsuario),

                "PJ" => new UsuarioLojista(usuarioef.IdUsuario, usuarioef.NomeCompleto,
                        new Email(usuarioef.Email),
                        new Cnpj(usuarioef.Documento), saldoUsuario),

                _ => throw new Exception("Tipo de Usuário inválido!")
            };

            return usuario;
        }
    }
}
