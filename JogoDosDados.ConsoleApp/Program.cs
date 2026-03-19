using System.Security.Cryptography;
namespace JogoDosDados.ConsoleApp;

class Program
{
  static void Main(string[] args)
  {
    const int limiteLinhaChegada = 30;
    const int bonusAvancoExtra = 3;
    const int penalidadeRecuo = 2;

    while (true)
    {

      Console.Clear();
      Console.WriteLine("---------------------------------------");
      Console.WriteLine("Jogo dos Dados");
      Console.WriteLine("---------------------------------------");
      int posicaoJogador = 0;
      bool jogoEstaEmAndamento = true;

      while (jogoEstaEmAndamento)
      {

        Console.Clear();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Jogo dos Dados");
        Console.WriteLine("---------------------------------------");

        Console.Write("\nPressione ENTER para lançar um dado...");
        Console.ReadLine();

        int resultado = RandomNumberGenerator.GetInt32(1, 7);

        Console.WriteLine($"\nO número sorteado foi: {resultado}");

        posicaoJogador += resultado;

        Console.WriteLine($"• Você está na posição {posicaoJogador} de {limiteLinhaChegada}");

        if (posicaoJogador == 5 || posicaoJogador == 10 || posicaoJogador == 15 || posicaoJogador == 25)
        {

          Console.WriteLine($"\n>> EVENTO: Avanço de {bonusAvancoExtra} casas!");
          posicaoJogador += bonusAvancoExtra;

          Console.WriteLine($"• Agora você está na posição {posicaoJogador} de {limiteLinhaChegada}");

        }

        else if (posicaoJogador == 7 || posicaoJogador == 13 || posicaoJogador == 20)
        {

          Console.WriteLine($"\n>> EVENTO: Recuo de {penalidadeRecuo} casas!");
          posicaoJogador -= penalidadeRecuo;

          Console.WriteLine($"• Agora você está na posição {posicaoJogador} de {limiteLinhaChegada}");

        }

        if (posicaoJogador >= limiteLinhaChegada)
        {

          Console.WriteLine("\n>> Parabéns! Você alcançou a linha de chegada.");
          jogoEstaEmAndamento = false;

        }

        Console.WriteLine("\n---------------------------------------");
        Console.Write("Pressione ENTER para continuar...");
        Console.ReadLine();

      }

      Console.Write("\nDeseja continuar? [s/N]: ");
      string? opcaoContinuar = Console.ReadLine()?.ToUpper();

      if (opcaoContinuar != "S")
        break;

    }

  }

}