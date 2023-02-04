using CadastroPessoa_Fisica_Juridica.Classes;
using System.Text.RegularExpressions;

//***************Metodos Genéricos *******************
PessoaJuridica metodosPj = new PessoaJuridica();
PessoaFisica metodosPf = new PessoaFisica();
List<PessoaFisica> ListaPf = new List<PessoaFisica>();// inicializa uma lista vazia de pessoa física
List<PessoaJuridica> ListaPj = new List<PessoaJuridica>();// inicializa uma lista vazia de pessoa jurídica

//*********************Cadastro da pessoa física**********************
// Cabeçalho do Sistema
Console.WriteLine(@$"
==============================================
|    Bem vindo ao sistema de cadastro de     |
|        Pessoas Físicas e Jurídicas         |
==============================================
");


Utils.Loading("Iniciando Meu Sistema ", 4, 300, ConsoleColor.Yellow, ConsoleColor.Red);

Console.WriteLine();//pula uma linha


Thread.Sleep(1500);//2000ms = 2s

string? opcao;

do
{
    //desenhar o menu
    Console.WriteLine(@$"
==============================================
|       Escolha uma das opções abaixo        |
|--------------------------------------------|
|           1 - Pessoa Física                |
|           2 - Pessoa Jurídica              |
|                                            |
|           0 - Sair                         |
==============================================
");

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
                Console.WriteLine(@$"
                ==============================================
                |       Escolha uma das opções abaixo        |
                |--------------------------------------------|
                |        1 - Cadastrar Pessoa Física         |
                |        2 - Listar Pessoa Física            |
                |                                            |
                |        0 - Voltar ao menu anterior         |
                ==============================================
                ");
                opcaoPf = Console.ReadLine();

                switch (opcaoPf)
                {
                    case "1"://cadastrar pessoa física
                        Utils.ParadaNoConsole("Opção Cadastrar Pessoa Física");
                        Console.Clear();
                        // Console.WriteLine($"*********************Cadastro da pessoa física**********************");
                        Console.WriteLine();//pula uma linha

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
                        ListaPf.Add(novaPf);//guarda uma pessoa física na lista

                        Utils.ParadaNoConsole("Pessoa Física Cadastrada com sucesso!!! ");

                        break;

                    case "2"://listar pessoa física
                             // EXIBIÇÃO
                        Console.Clear();
                        Console.WriteLine("**********Listagem de Pessoas Físicas***********");//pula uma linha

                        foreach (var pessoa in ListaPf)
                        {//cada pessoa cadastrada
                            Console.WriteLine();//pula uma linha
                            Console.WriteLine($"Nome: {pessoa.Nome}");
                            Console.WriteLine($"CPF: {pessoa.Cpf}");
                            Console.WriteLine($"Rendimento: {pessoa.Rendimento}");
                            Console.WriteLine($"Rendimento Líquido: {metodosPf.PagarImposto(pessoa.Rendimento)}");
                            Console.WriteLine($"Data Nascimento {pessoa.DataNascimento}");
                            // Console.WriteLine($"Maior de idade? {pessoa.ValidarDataNascimento(pessoa.DataNascimento)}");
                            Console.WriteLine(metodosPf.ValidarDataNascimento(pessoa.DataNascimento) ? "Maior de Idade: Sim" : "Maior de Idade: Não");                            
                            Console.WriteLine($"Rua: {pessoa.Endereco.Logradouro}");
                            Console.WriteLine($"Número: {pessoa.Endereco.Numero}");
                            // Console.WriteLine($"Endereço Comercial ? {pessoa.Endereco.Comercial}");
                            // string endComercial = (pessoa.Endereco.Comercial == true ) ? "Endereço Comercial? sim " : "Endereço Comercial? Não ";
                            // Console.WriteLine(endComercial);                            
                            Console.WriteLine((pessoa.Endereco.Comercial) ? "Endereço Comercial? sim" : "Endereço Comercial? Não");                            

                            // if (pessoa.Endereco.Comercial == true)
                            // {
                            //     Console.WriteLine($"Endereço Comercial? Sim ");
                            // }
                            // else
                            // {
                            //     Console.WriteLine($"Endereço Comercial? Não ");
                            // }
                        }
                        Console.WriteLine();//linha vazia
                        Utils.ParadaNoConsole("********** Fim da listagem ***********");
                        break;

                    case "0"://volta ao menu anterior
                        Console.Clear();
                        Utils.ParadaNoConsole("Voltando ao menu anterior");
                        break;

                    default://qualquer opção diferente do menu
                        Console.Clear();
                        Utils.ParadaNoConsole("***** Opção Inválida *****");
                        break;
                }

            } while (opcaoPf != "0");// fim do sub-menu


            Console.WriteLine();//pula uma linha
            Utils.ParadaNoConsole("********** Pessoa Física cadastrada com sucesso ***********");
            break;

        case "2"://**************Cadastro da pessoa jurídica************************
            Console.Clear();
            Console.WriteLine();//pula uma linha
            Console.WriteLine($"**************Cadastro da pessoa jurídica************************");
            //CADASTRO
            Endereco endPj = new Endereco();
            endPj.Logradouro = "Rua da Luz";
            endPj.Numero = 02;
            endPj.Comercial = true;

            PessoaJuridica novaPj = new PessoaJuridica();

            novaPj.Nome = "Beltrano";
            novaPj.Endereco = endPj;
            novaPj.Rendimento = 5000.01F;
            novaPj.Cnpj = "15.321.584/0001-74";
            // novaPj.Cnpj = "15321584000174";
            novaPj.Fantasia = "ONDA_GAME";
            novaPj.RazaoSocial = "Serviço Profissional de Aprimoramento de Equipamentos Gamers";

            //************Exibição dos dados***************
            Console.WriteLine(@$"
Razão Social: {novaPj.RazaoSocial}
Nome Fantasia: {novaPj.Fantasia}
Representante: {novaPj.Nome}
CNPJ: {novaPj.Cnpj}
CNPJ Válido: {metodosPj.ValidarCnpj(novaPj.Cnpj)}
Rendimento Anual: {novaPj.Rendimento}
Rendimento Líquido: {metodosPj.PagarImposto(novaPj.Rendimento)}
Endereço: {novaPj.Endereco.Logradouro}, {novaPj.Endereco.Numero}
Endereço Comercial : {novaPj.Endereco.Comercial}
");
            Utils.ParadaNoConsole("Pessoa Jurídica cadastrada com sucesso");
            break;

        case "0":
            Console.Clear();
            Utils.ParadaNoConsole("Obrigado por utilizar o Sistema!!!!");
            break;

        default:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red; //cor da fonte
            Utils.ParadaNoConsole("Opção Inválida"); //parada no console
            Console.ResetColor();
            break;
    }
} while (opcao != "0");
Utils.Loading("Finalizando Meu Sistema", 4, 400);
Console.WriteLine();//pula uma linha

// DateTime data = new DateTime(1980, 8, 20);
// Console.WriteLine(pessoa.ValidarDataNascimento(data));


//***********ESTUDOS DE CASO****************

// Substring
// .........0123456789..................
// string nome - "Fulano de tal";
// Console.WriteLine( nome.Substrinf(3));
// Console.WriteLine( nome.Substrinf(8));
// Console.WriteLine( nome.Substrinf(0, 4));
// Console.WriteLine( nome.Substrinf(4, 5));
// Console.WriteLine( nome.Substrinf(NotImplementedException.Length));


// string data = "11/12/2022";

// bool dataValida = Regex.IsMatch(data, @"^\d{2}/\d{2}/\d{4}$");

// Console.WriteLine(data);
// Console.WriteLine(dataValida);

// if (dataValida)
// {    
//     String[] partes = data.Split("/");

//     if ( int.Parse(partes[1]) >= 1 && int.Parse(partes[1]) <= 12 )
// {
//     Console.WriteLine("Mês Válido");
// }
// else
// {
//     Console.WriteLine("Mês INVÁLIDO");
// }
// }
//ESTUDO DE CASO PJ
// EXEMPLO COM O USUÁRIO DIGITANDO/ dando INPUT OS DADOS
// Console.WriteLine($"Nome Fantasia?");
// novaPj.Fantasia = Console.ReadLine();
// Console.WriteLine($"Qual é o Rendimento");
// novaPj.Rendimento = float.Parse(Console.ReadLine());
