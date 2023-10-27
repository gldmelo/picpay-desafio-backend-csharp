
namespace PicPay.Desafio.API.Versions.V1.Models.Usuario
{
    /// <summary>
    /// Armazena os dados de Login do usuário para autenticação na API
    /// </summary>
    public class CredencialUsuario
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
