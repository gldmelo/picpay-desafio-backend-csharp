using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicPay.Desafio.Domain.ValueObjects;

namespace PicPay.Desafio.Application.Services.Usuario
{
	public interface IUsuarioService
	{
        //public UsuarioDto ObterUsuarioByEmail(string email);

        /// <summary>
        /// Obtém o saldo do usuário
        /// </summary>
        public Dinheiro ObterSaldo(string emailUsuario);

	}
}
