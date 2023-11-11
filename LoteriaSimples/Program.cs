// See https://aka.ms/new-console-template for more information

using LoteriaSimples;

void MostraCabecalho()
{
    string descricao = $"{new string('-', 10)} Loteria Simples {new string('-', 10)}";

    Console.WriteLine(new string('-', descricao.Length));
    Console.WriteLine(descricao);
    Console.WriteLine(new string('-', descricao.Length));
    Console.WriteLine();
}

void MostraMenu()
{
    int opcao;

    do
    {
        Console.WriteLine("Escolha uma opção");
        Console.WriteLine("1 - Gerar aposta");
        Console.WriteLine("2 - Sair");

        var entrada = Console.ReadLine();
        
        if (!int.TryParse(entrada, out opcao))
        {
            Console.WriteLine("Opção inválida!");
            continue;
        }
            
        if (opcao == 1)
            GerarNumeros();

    } while (opcao != 2);
}

void MostraCabecalhoResltados(string descricao)
{
    var descricaoResultadoFmt = FormatarCabecalhoResultado(descricao);

    Console.WriteLine(new string('-', descricaoResultadoFmt.Length));
    Console.WriteLine(descricaoResultadoFmt);
    Console.WriteLine(new string('-', descricaoResultadoFmt.Length));
}

void GerarNumeros()
{
    Console.Write("Informe o número de jogos desejados: ");
    int qtdJogos = Convert.ToInt32(Console.ReadLine());

    Console.Write("Informe o número máximo para este jogo: ");
    int nroMaximo = Convert.ToInt16(Console.ReadLine());

    Console.Write("Informe a quantidade de números: ");
    int qtdNumeros = Convert.ToInt16(Console.ReadLine());

    var descricaoResultados = " Jogos gerados ";
    MostraCabecalhoResltados(descricaoResultados);

    var i = 0;
    while (qtdJogos > 0)
    {
        var aposta = new Aposta(++i, qtdNumeros, nroMaximo);
        var numeros = aposta.Gerar();
        Console.WriteLine("Jogo {0}: {1}", i, numeros.Resultado);

        qtdJogos--;
    }

    MostraRodapeResultados(descricaoResultados);
}

void MostraRodapeResultados(string descricao)
{
    var descricaoResultadoFmt = FormatarCabecalhoResultado(descricao);
    Console.WriteLine(new string('-', descricaoResultadoFmt.Length));
}

MostraCabecalho();
MostraMenu();

static string FormatarCabecalhoResultado(string descricao)
{
    return string.Concat(
            new string('-', descricao.Length / 3),
            descricao,
            new string('-', descricao.Length / 3)
        );
}