// See https://aka.ms/new-console-template for more information

using LoteriaSimples;

class Program
{
    static void Main(string[] args)
    {
           
        do
        {
            MostraCabecalho();
            MostraMenu();
            
            Console.WriteLine("Continua? <s/n>");
        } while (Console.ReadLine()?.ToLower() == "s");
    }

    static void MostraCabecalho()
    {
        string descricao = $"{new string('-', 10)} Loteria Simples {new string('-', 10)}";

        Console.WriteLine(new string('-', descricao.Length));
        Console.WriteLine(descricao);
        Console.WriteLine(new string('-', descricao.Length));
        Console.WriteLine();
    }

    static void MostraMenu()
    {
        MostraOpcoesMenu();

        var entrada = Console.ReadLine();
        var opcoesValidas = new[] { 1, 2, 3 };

        if (!int.TryParse(entrada, out int opcao) && !opcoesValidas.Contains(opcao))
        {
            Console.WriteLine("Opção inválida!");
            return;
        }

        if (opcao == opcoesValidas.Last())
            Console.Clear();
        else
            GerarNumeros(opcao != 1);        
    }

    static void MostraOpcoesMenu()
    {
        Console.WriteLine("Escolha uma opção");
        Console.WriteLine("1 - Gerar apostas individuais (podendo haver repetições)");
        Console.WriteLine("2 - Gerar apostas consolidado (sem repetições)");
        Console.WriteLine("3 - Limpar a tela");
    }

    static void MostraCabecalhoResultados(string descricao)
    {
        var descricaoResultadoFmt = FormatarCabecalhoResultado(descricao);

        Console.WriteLine(new string('-', descricaoResultadoFmt.Length));
        Console.WriteLine(descricaoResultadoFmt);
        Console.WriteLine(new string('-', descricaoResultadoFmt.Length));
    }

    static void GerarNumeros(bool consolidar = false)
    {
        Console.Write("Informe o número de jogos desejados: ");
        int qtdJogos = Convert.ToInt32(Console.ReadLine());

        Console.Write("Informe o número máximo para este jogo: ");
        int nroMaximo = Convert.ToInt16(Console.ReadLine());

        Console.Write("Informe a quantidade de números: ");
        int qtdNumeros = Convert.ToInt16(Console.ReadLine());

        var descricaoResultados = " Jogos gerados ";
        MostraCabecalhoResultados(descricaoResultados);

        var i = 0;
        var numeros = new List<int>();

        while (qtdJogos > 0)
        {
            var aposta = new Aposta(++i, qtdNumeros, nroMaximo);
            var retorno = aposta.Gerar(numeros.ToArray());

            if (consolidar)
                numeros.AddRange(retorno.NumerosSorteados);

            Console.WriteLine("Jogo {0}: {1}", i, retorno.Resultado);

            qtdJogos--;
        }

        MostraRodapeResultados(descricaoResultados);
    }

    static void MostraRodapeResultados(string descricao)
    {
        var descricaoResultadoFmt = FormatarCabecalhoResultado(descricao);
        Console.WriteLine(new string('-', descricaoResultadoFmt.Length));
    }

    static string FormatarCabecalhoResultado(string descricao)
    {
        return string.Concat(
                new string('-', descricao.Length / 3),
                descricao,
                new string('-', descricao.Length / 3)
            );
    }    
}