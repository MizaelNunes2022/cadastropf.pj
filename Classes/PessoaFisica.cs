using CadastroPessoa_Fisica_Juridica.Interfaces;

namespace CadastroPessoa_Fisica_Juridica.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        //Metodo de sobrecarga
        public PessoaFisica()
        {

        }

        public PessoaFisica(string parCpf)
        {
            this.Cpf = parCpf;
        }

        public string? Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        //Pessoa física
        //Para rendimentos até R$1.500,00 - isento (desconto 0)
        //Para rendimentos entre R$1.501,00 e R$5.000,01 - desconto de 3%
        //Para rendimentos acima de R$5.000,01 - desconto de 5%.

        public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 1500) //isento
            {
                return rendimento;
            }
            else if (rendimento <= 5000)
            {//3% de desconto
                return rendimento - ((rendimento / 100) * 3);
            }
            else
            {//5%
                return rendimento - rendimento / 100 * 5;
            }
        }

        public bool ValidarDataNascimento(DateTime dataNasc)
        {
            DateTime dataAtual = DateTime.Today;
            double idade = (dataAtual - dataNasc).TotalDays / 365;

            if (idade >= 18)
            {
                return true;
            }

            return false;
        }


        public bool ValidarDataNascimento(String dataNasc)
        {
            DateTime dataConvertida;

            if (DateTime.TryParse(dataNasc, out dataConvertida))
            {
                // Console.WriteLine(dataConvertida);
                DateTime dataAtual = DateTime.Today;
                double idade = (dataAtual - dataConvertida).TotalDays / 365;

                // Console.WriteLine(dataAtual);
                // Console.WriteLine(idade);

                if (idade >= 18)
                {
                    return true;
                }
            }

            return false;
        }
    }
}