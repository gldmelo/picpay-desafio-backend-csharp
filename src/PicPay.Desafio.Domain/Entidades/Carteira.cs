using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPay.Desafio.Domain.Entidades
{
    public class Carteira
    {
        protected decimal Saldo {  get; set; }

        public Carteira()
        {
            Saldo = 0;
        }


    }
}
