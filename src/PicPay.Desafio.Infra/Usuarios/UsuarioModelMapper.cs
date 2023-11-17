using PicPay.Desafio.Application.Usuarios;
using PicPay.Desafio.Infra.Usuarios.Models;

namespace PicPay.Desafio.Infra.Usuarios
{
    public static class UsuarioModelMapper
    {
        /// <summary>
        /// Converte um objeto usuário do banco de dados em um objeto DTO de Usuario
        /// Essa passagem serve para enviar um objeto "limpo" de eventuais marcações de frameworks ORM, tal como Entity Framework Core
        /// </summary>
        public static UsuarioDto ConvertToDto(this UsuarioModel usuarioModel)
        {
            var usuario = new UsuarioDto
            {
                Id = usuarioModel.Id_usuario,
                Email = usuarioModel.Email,
                NomeCompleto = usuarioModel.Nome_completo,
                Tipo = usuarioModel.Tipo,
            };

            return usuario;
        }
    }
}
