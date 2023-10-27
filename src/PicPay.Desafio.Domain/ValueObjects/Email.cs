
namespace PicPay.Desafio.Domain.ValueObjects
{
    public class Email
    {
        public string Endereco { get; }
        
        public Email(string email)
        {
            //TODO: Validação usando Regex

            Endereco = email;
        }
    }
}
