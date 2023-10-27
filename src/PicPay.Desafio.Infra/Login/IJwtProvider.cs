
namespace PicPay.Desafio.Infra.Login
{
    public interface IJwtProvider
    {
        string GerarTokenJwt(string email);
    }
}
