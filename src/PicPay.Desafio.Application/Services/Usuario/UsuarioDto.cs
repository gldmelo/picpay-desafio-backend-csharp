using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicPay.Desafio.Domain.ValueObjects;

namespace PicPay.Desafio.Application.Services.Usuario
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string NomeCompleto { get; }
        public string Email { get; }
    }
}
