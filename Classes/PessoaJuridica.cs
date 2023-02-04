using CadastroPessoa_Fisica_Juridica.Interfaces;
using System.Text.RegularExpressions;

namespace CadastroPessoa_Fisica_Juridica.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string? Cnpj { get; set; }
        public string? RazaoSocial { get; set; }
        public string? Fantasia { get; set; }

        // PessoaJuridica
        // Para rendimento até R$5.000,00 - desconto de 6%
        // Para rendimentos entre R$5.001,00 e R$10.000,00 - desconto de 8%
        // Para rendimentos acima de R$10.000,01 - desconto de 10%

        public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 5000)
            {//6%
                return rendimento - rendimento / 100 * 6;
            }
            else if (rendimento <= 10000)
            {//8%
                return rendimento - rendimento / 100 * 8;
            }
            else
            {//10%
                return rendimento - rendimento / 100 * 10;
            }
        }




        public bool ValidarCnpj(string cnpj)
        {
            // 15.321.584/0001-74    18 dígitos
            //15321584000174        14 dígitos    
            //Verificar se tem o 001        

            if (Regex.IsMatch(cnpj, @"^(\d{2}.\d{3}.\d{3}.\d{4}-\d{2})|(\d{14})$"))
            {

                if (cnpj.Length == 18)
                {//18 dígitos
                    if (cnpj.Substring(11, 4) == "0001")
                    {// 0001
                        return true;
                    }
                }
                else if (cnpj.Length == 14)
                {//14 dígitos
                    if (cnpj.Substring(8, 4) == "0001")
                    {// 0001
                        return true;
                    }
                }

            }
            return false;
        }
    }
}