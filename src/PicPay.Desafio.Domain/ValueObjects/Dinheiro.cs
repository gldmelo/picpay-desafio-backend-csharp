using FluentResults;

namespace PicPay.Desafio.Domain.ValueObjects
{
    public struct Dinheiro
    {
        public decimal Quantia { get; }
        public string Moeda { get; set; }

        public Dinheiro(decimal quantia) : this(quantia, "BRL") { }

        public Dinheiro(decimal quantia, string moeda)
        {
            if (string.IsNullOrEmpty(moeda))
                throw new Exception("Uma moeda deve ser informada.");

            Quantia = quantia;
            Moeda = moeda;
        }

        public static Result<Dinheiro> operator + (Dinheiro d1, Dinheiro d2)
        {
            if (d1.Moeda != d2.Moeda)
                throw new Exception("Não é possível somar dinheiro de moedas diferentes");

            return new Dinheiro(d1.Quantia + d2.Quantia, d1.Moeda);
        }

        public static bool operator < (Dinheiro d1, Dinheiro d2)
        {
            if (d1.Moeda != d2.Moeda)
                throw new Exception("Não é possível comparar dinheiro de moedas diferentes");

            return d1.Quantia < d2.Quantia;
        }

        public static bool operator > (Dinheiro d1, Dinheiro d2)
        {
            if (d1.Moeda != d2.Moeda)
                throw new Exception("Não é possível comparar dinheiro de moedas diferentes");

            return d1.Quantia > d2.Quantia;
        }

        public static bool operator <= (Dinheiro d1, Dinheiro d2)
        {
            if (d1.Moeda != d2.Moeda)
                throw new Exception("Não é possível comparar dinheiro de moedas diferentes");

            return d1.Quantia <= d2.Quantia;
        }

        public static bool operator >= (Dinheiro d1, Dinheiro d2)
        {
            if (d1.Moeda != d2.Moeda)
                throw new Exception("Não é possível comparar dinheiro de moedas diferentes");

            return d1.Quantia >= d2.Quantia;
        }

    }
}
