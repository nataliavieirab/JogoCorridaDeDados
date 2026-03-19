using System.Security.Cryptography;
namespace JogoDosDados.ConsoleApp;

class Program
{
  static void Main(string[] args)
  {
    const int limiteLinhaChegada = 30;

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

        if (posicaoJogador < limiteLinhaChegada)
          Console.WriteLine($">> Você está na posição {posicaoJogador} de {limiteLinhaChegada}");
        else
        {
          Console.WriteLine(">> Parabéns! Você alcançou a linha de chegada.");
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