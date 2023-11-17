
namespace PicPay.Desafio.Infra.Usuarios.Models;

public partial class UsuarioModel
{
    public int Id_usuario { get; set; }

    public string Email { get; set; } = null!;

    public string Nome_completo { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string Documento { get; set; } = null!;

}
