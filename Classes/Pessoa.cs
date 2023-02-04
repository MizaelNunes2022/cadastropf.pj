using CadastroPessoa_Fisica_Juridica.Interfaces;

namespace CadastroPessoa_Fisica_Juridica.Classes
{
    public abstract class Pessoa : IPessoa
    {
        public string ?Nome {get;set;}

        public Endereco ?Endereco {get;set;}

        public float Rendimento {get;set;}

        public abstract float PagarImposto(float rendimento);
        
    }
}