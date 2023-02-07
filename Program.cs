using CadastroPessoa_Fisica_Juridica.Classes;
using System.Text.RegularExpressions;

//***************Metodos Genéricos *******************
PessoaJuridica metodosPj = new PessoaJuridica();
PessoaFisica metodosPf = new PessoaFisica();
List<PessoaFisica> ListaPf = new List<PessoaFisica>(); // inicializa uma lista vazia de pessoa física
List<PessoaJuridica> ListaPj = new List<PessoaJuridica>(); // inicializa uma lista vazia de pessoa jurídica

//*********************Cadastro da pessoa física**********************
// Cabeçalho do Sistema
Console.WriteLine(
    @$"
==============================================
|    Bem vindo ao sistema de cadastro de     |
|        Pessoas Físicas e Jurídicas         |
==============================================
"
);

Utils.Loading("Iniciando Meu Sistema ", 4, 300, ConsoleColor.Yellow, ConsoleColor.Red);

Console.WriteLine(); //pula uma linha

Thread.Sleep(1500); //2000ms = 2s

string? opcao;

do
{
    //desenhar o menu
    Console.WriteLine(
        @$"
==============================================
|       Escolha uma das opções abaixo        |
|--------------------------------------------|
|           1 - Pessoa Física                |
|           2 - Pessoa Jurídica              |
|                                            |
|           0 - Sair                         |
==============================================
"
    );

    opcao = Console.ReadLine();
    // espera o usuário digitar a opção
    // escolha a opção
    //faz algo, e só depois pergunta se é pra continuar

    switch (opcao)
    {
        case "1": //**Cadastro da pessoa física************
            string opcaoPf;
            do
            {
                //desenhar o sub-menu
                Console.WriteLine(
                    @$"
                ==============================================
                |       Escolha uma das opções abaixo        |
                |--------------------------------------------|
                |        1 - Cadastrar Pessoa Física         |
                |        2 - Listar Pessoa Física            |
                |                                            |
                |        0 - Voltar ao menu anterior         |
                ==============================================
                "
                );
                opcaoPf = Console.ReadLine();

                switch (opcaoPf)
                {
                    case "1": //cadastrar pessoa física
                        Utils.ParadaNoConsole("Opção Cadastrar Pessoa Física");
                        Console.Clear();
                        // Console.WriteLine($"*********************Cadastro da pessoa física**********************");
                        Console.WriteLine(); //pula uma linha

                        //CADASTRO preenchimento dos dados
                        //Endereço pessoa fisica 1
                        Endereco enderecoPf = new Endereco();
                        Console.WriteLine($"Digite o Endereço: ");
                        enderecoPf.Logradouro = Console.ReadLine();
                        Console.WriteLine($"Digite o número: ");
                        enderecoPf.Numero = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Endereço comercial? s/n: ");
                        string comercial = Console.ReadLine();
                        if (comercial == "s")
                        {
                            enderecoPf.Comercial = true;
                        }
                        else
                        {
                            enderecoPf.Comercial = false;
                        }

                        //pessoa Física 1
                        PessoaFisica novaPf = new PessoaFisica();
                        Console.WriteLine($"Digite o nome");
                        novaPf.Nome = Console.ReadLine();
                        novaPf.DataNascimento = new DateTime(1985, 10, 20);
                        Console.WriteLine($"Digite o CPF: ");
                        novaPf.Cpf = Console.ReadLine();
                        Console.WriteLine($"Informe o rendimento Bruto: ");
                        novaPf.Rendimento = float.Parse(Console.ReadLine());
                        novaPf.Endereco = enderecoPf;

                        //cadastrando na lista
                        ListaPf.Add(novaPf); //guarda uma pessoa física na lista

                        Utils.ParadaNoConsole("Pessoa Física Cadastrada com sucesso!!! ");

                        break;

                    case "2": //listar pessoa física
                        // EXIBIÇÃO
                        Console.Clear();
                        Console.WriteLine("**********Listagem de Pessoas Físicas***********"); //pula uma linha

                        foreach (var pessoa in ListaPf)
                        { //cada pessoa cadastrada
                            Console.WriteLine(); //pula uma linha
                            Console.WriteLine($"Nome: {pessoa.Nome}");
                            Console.WriteLine($"CPF: {pessoa.Cpf}");
                            Console.WriteLine($"Rendimento: {pessoa.Rendimento}");
                            Console.WriteLine(
                                $"Rendimento Líquido: {metodosPf.PagarImposto(pessoa.Rendimento)}"
                            );
                            Console.WriteLine($"Data Nascimento {pessoa.DataNascimento}");
                            // Console.WriteLine($"Maior de idade? {pessoa.ValidarDataNascimento(pessoa.DataNascimento)}");
                            Console.WriteLine(
                                metodosPf.ValidarDataNascimento(pessoa.DataNascimento)
                                    ? "Maior de Idade: Sim"
                                    : "Maior de Idade: Não"
                            );
                            Console.WriteLine($"Rua: {pessoa.Endereco.Logradouro}");
                            Console.WriteLine($"Número: {pessoa.Endereco.Numero}");
                            // Console.WriteLine($"Endereço Comercial ? {pessoa.Endereco.Comercial}");
                            // string endComercial = (pessoa.Endereco.Comercial == true ) ? "Endereço Comercial? sim " : "Endereço Comercial? Não ";
                            // Console.WriteLine(endComercial);
                            Console.WriteLine(
                                (pessoa.Endereco.Comercial)
                                    ? "Endereço Comercial? sim"
                                    : "Endereço Comercial? Não"
                            );

                            // if (pessoa.Endereco.Comercial == true)
                            // {
                            //     Console.WriteLine($"Endereço Comercial? Sim ");
                            // }
                            // else
                            // {
                            //     Console.WriteLine($"Endereço Comercial? Não ");
                            // }
                        }
                        Console.WriteLine(); //linha vazia
                        Utils.ParadaNoConsole("********** Fim da listagem ***********");
                        break;

                    case "0": //volta ao menu anterior
                        Console.Clear();
                        Utils.ParadaNoConsole("Voltando ao menu anterior");
                        break;

                    default: //qualquer opção diferente do menu
                        Console.Clear();
                        Utils.ParadaNoConsole("***** Opção Inválida *****");
                        break;
                }
            } while (opcaoPf != "0"); // fim do sub-menu

            Console.WriteLine(); //pula uma linha
            Utils.ParadaNoConsole("********** Pessoa Física cadastrada com sucesso ***********");
            break;

        case "2":
            string opcaoPj;
            do
            {
                //SUB - MENU
                Console.WriteLine(
                    @$"
===========================================
|       Escolha uma das opções abaixo     |
|-----------------------------------------|
|       1 - Cadastrar pessoa júridica     |              
|       2 - Listar Pessoa Júridica        |
|                                         |
|       0 - Voltar ao menu principal      |               
===========================================
            "
                );
                opcaoPj = Console.ReadLine();

                switch (opcaoPj)
                {
                    case "1": //Cadastrando pessoa júridica
                        Console.Clear();
                        // //************Cadastro de pessoa Júridica, preenchimento dos dados**********\\

                        /// Instanciando classse (que é uma composição) endereço e colocando valor nas variaveis.
                        Endereco endPj = new Endereco();
                        /// Instanciando a classe Endereço//
                        PessoaJuridica novaPj = new PessoaJuridica();
                        Console.WriteLine($"Digite o endereço:");
                        endPj.Logradouro = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Digite o número:");
                        endPj.Numero = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine($"Endereço é comercial ? S/N");
                        string comercial = Console.ReadLine();
                        if (comercial == "S")
                        {
                            endPj.Comercial = true;
                        }
                        else
                            endPj.Comercial = false;

                        Console.WriteLine($"Digite o Nome:");
                        novaPj.Nome = Console.ReadLine();
                        // Instanciano classe PessoaJuridica e colocando valor em sua variaveis.
                        // Instanciando um obejto para chamar os métodos.


                        using (StreamWriter sw = new StreamWriter($"{novaPj.Nome}.txt"))
                        {
                            sw.WriteLine(novaPj.Nome);
                        }

                        // novaPj.Endereco = endPj;
                        // Console.WriteLine($"Digite o Rendimento:");
                        // novaPj.Rendimento = float.Parse( Console.ReadLine());
                        // Console.WriteLine($"Digite o CNPJ:");
                        // novaPj.Cnpj = Console.ReadLine();
                        // // novaPj.Cnpj = "020231340001331";
                        // Console.WriteLine($"Digite a razão social:");
                        // novaPj.RazaoSocial = Console.ReadLine();
                        //  Console.WriteLine($"Digite o nome fantasia:");
                        // novaPj.NomeFantasia = Console.ReadLine();
                        // //Cadastro na lista
                        // listaPj.Add(novaPj);



                        Utils.ParandoConsole("Pessoa Júridica cadastrada com sucesso!");
                        break;
                    case "2": // listando pessoa júridica
                        // *******Exibir dados*******\\
                        Console.Clear();
                        Console.WriteLine("****Listagem de Pessoa Júridica****");

                        // foreach (var pessoa in listaPj)
                        // {
                        //     Console.WriteLine($"");
                        //     Console.WriteLine(@$"

                        // Empresa : {pessoa.RazaoSocial}
                        // Nome Fantasia : {pessoa.NomeFantasia}
                        // Representante : {pessoa.Nome}
                        // CNPJ é Válido? : {MetodosPj.ValidarCnpj(pessoa.Cnpj)}
                        // Redimento Anual  : {pessoa.Rendimento}
                        // Redimento Liquido   : {MetodosPj.PagarImposto(pessoa.Rendimento)}
                        // Endereço : {pessoa.Endereco.Logradouro}
                        // Número : {pessoa.Endereco.Numero}
                        // ");
                        // //Operadores Ternários
                        //  //string endComercial = (pessoa.Endereco.Comercial == true) ? "Endereço comercial? Sim": "Endereço comercial? Não";
                        // Console.WriteLine( (pessoa.Endereco.Comercial == true) ? "Endereço comercial? Sim": "Endereço comercial? Não");
                        // }


                        //Leitura dos dados txt
                        using (StreamReader sr = new StreamReader("User1.txt"))
                        {
                            string linha;
                            while ((linha = sr.ReadLine()) != null)
                            {
                                Console.WriteLine(linha);
                            }
                            Console.WriteLine($"Tecle enter para continuar");
                            Console.ReadLine();
                        }

                        Console.WriteLine();
                        Utils.ParandoConsole("Fim da listagem");
                        break;

                    case "0": // voltando ao menu
                        Console.Clear();
                        Utils.ParandoConsole("Opção Voltando ao menu");
                        break;
                    default: // Opção inválida!
                        Console.Clear();
                        Utils.ParandoConsole("Opção inválida!");
                        break;
                }
            } while (opcaoPj != "0");

            Console.Clear();

            break;

        case "1":
            //***********Cadastro de Pessoa Fisica************\\
            string? opcaoPf;
            do
            {
                Console.WriteLine(
                    @$"
===========================================
|       Escolha uma das opções abaixo     |
|-----------------------------------------|
|       1 - Cadastrar pessoa Fisica       |              
|       2 - Listar Pessoa Fisica          |
|                                         |
|       0 - Voltar ao menu principal      |               
===========================================
            "
                );
                opcaoPf = Console.ReadLine();
                switch (opcaoPf)
                {
                    case "1":
                        Console.Clear();

                        Endereco endfpf1 = new Endereco(); // Instanciando Classe endereço New Endereço()
                        endfpf1.Logradouro = "Endereço 1";
                        endfpf1.Numero = 50;
                        endfpf1.Comercial = false;

                        //declara o valor do objeto
                        pf1.Cpf = "222.333.444-55"; //declara o valor do objeto(Atributo )
                        pf1.DataNascimento = new DateTime(2000, 05, 14);
                        pf1.Rendimento = 1499.99f;
                        pf1.Nome = "User1";
                        pf1.Endereco = endfpf1; // Indicando que endereço  é igual a instanacia e endpf1 da classe Endereco
                        Utils.ParandoConsole("Pessoa Fisica cadastrada com sucesso!");
                        break;

                    case "2":
                        //Insere dados No Database
                        MetodosPf.Inserir(pf1);
                        List<PessoaFisica> ListaExibicaoPf = MetodosPf.LerArquivo();

                        foreach (PessoaFisica PessoaDaLista in ListaExibicaoPf)
                        {
                            // Exibição dos dados\\
                            Console.Clear();

                            Console.WriteLine($"Nome: {PessoaDaLista.Nome}"); // objetos e seus valores
                            Console.WriteLine($"CPF: {PessoaDaLista.Cpf}"); // objetos e seus valores
                            // Console.WriteLine($"Data de nascimento: {PessoaDaLista.DataNascimento}");// objetos e seus valores
                            // Console.WriteLine($"Rendimento: {PessoaDaLista.Rendimento}");
                            // Console.WriteLine($"Rendimento liquido: {MetodosPf.PagarImposto(PessoaDaLista.Rendimento)}");//Rendimento liquido
                            // objetos e seus valores
                            // Console.WriteLine($"Logradouro: {PessoaDaLista.Endereco.Logradouro}");// objetos e seus valores
                            // Console.WriteLine($"Número: {PessoaDaLista.Endereco.Numero}");// objetos e seus valores
                            // Console.WriteLine($"Endereço comercial ? {PessoaDaLista.Endereco.Comercial}");// objetos e seus valores
                            // Console.WriteLine($"Maior de Idade? {PessoaDaLista.ValidarDataNascimento(PessoaDaLista.DataNascimento)}");// Pega a data de nascimento Usa o método para calcular e retorna se é maior de idade.
                            //                                                                                       //Console.WriteLine($"Maior de Idade? {pf1.ValidarDataNascimento(14/05/2000)}") // Do método String de ValidarDataDeNascimento
                            DateTime data = new DateTime(2000, 5, 14);

                            Console.WriteLine($"");
                            Console.WriteLine($"Digite enter para continuar");
                            Console.ReadLine();
                        }

                        // Console.Write(ListaExibicaoPf);
                        Console.WriteLine($""); //Quebra do texto
                        Utils.ParandoConsole("Pessoa física Exibida com sucesso!");
                        Console.Clear();
                        break;
                    case "0":
                        Utils.ParandoConsole("Obrigado por usar o nosso sistema!");
                        Console.Clear();
                        break;
                    default:
                        Utils.ParandoConsole("Opção inválida!", ConsoleColor.Red); // Cor opcional Como parametro //Estudo de caso
                        Console.ResetColor(); // Reseta cor
                        break;
                }
            } while (opcaoPf != "0");

            break;

        case "0":

            Utils.ParandoConsole("Obrigado por usar o nosso sistema!");
            Console.Clear();
            break;

        default:
            Utils.ParandoConsole("Opção inválida!", ConsoleColor.Red); // Cor opcional Como parametro //Estudo de caso
            Console.ResetColor(); // Reseta cor

            break;
    }
} while (opcao != "0"); // repetição do código

Utils.Loading("Finalizando Sitema ", 3, 500);
Console.ResetColor(); // Reseta cor
Console.WriteLine($"");

///Quebra de linha
Console.WriteLine($"Fim do Progama!");