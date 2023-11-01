using DesafioFundamentos.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n");
Console.WriteLine("Digite o preço inicial: ");

bool entradaValida = false;

while (!entradaValida)
{
    string entradaUsuario = Console.ReadLine();

    if (decimal.TryParse(entradaUsuario, out precoInicial) && precoInicial >= 0)
    {
        entradaValida = true;
    }
    else
    {
        Console.WriteLine("Entrada inválida. Certifique-se de digitar um valor positivo.");
        Console.WriteLine("Digite o preço inicial: ");
    }
}

entradaValida = false;

Console.WriteLine("\nAgora digite o preço por hora: ");

while (!entradaValida)
{
    string entradaUsuario = Console.ReadLine();

    if (decimal.TryParse(entradaUsuario, out precoPorHora) && precoPorHora >= 0)
    {
        entradaValida = true;
    }
    else
    {
        Console.WriteLine("Valor inválido\n");
        Console.WriteLine("Digite o preço por hora: ");
    }
}

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("\nDigite a sua opção:");
    Console.WriteLine("\n1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("\nOpção inválida");
            break;
    }

    Console.WriteLine("\nPressione uma tecla para continuar");
    Console.ReadLine();

}

Console.WriteLine("O programa se encerrou");
