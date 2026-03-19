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
      Console.WriteLine("=======================================");
      Console.WriteLine("JOGO CORRIDA DE DADOS");
      Console.WriteLine("=======================================");

      int posicaoJogador = 0;
      int posicaoComputador = 0;

      bool jogoEstaEmAndamento = true;

      while (jogoEstaEmAndamento)
      {

        Console.Clear();
        Console.WriteLine("=======================================");
        Console.WriteLine("JOGO CORRIDA DE DADOS");
        Console.WriteLine("=======================================");
        Console.WriteLine("\n---------- Rodada do Jogador ----------");

        Console.Write("\nPressione ENTER para lançar um dado...");
        Console.ReadLine();

        int resultadoJogador = RandomNumberGenerator.GetInt32(1, 7);

        Console.WriteLine($"\nO número sorteado foi: {resultadoJogador}");

        posicaoJogador += resultadoJogador;

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

          Console.Write("\nPressione ENTER para continuar...");
          Console.ReadLine();
          continue;

        }

        Console.Write("\nPressione ENTER para continuar...");
        Console.ReadLine();

        Console.WriteLine("\n-------- Rodada do Computador ---------");

        int resultadoComputador = RandomNumberGenerator.GetInt32(1, 7);

        Console.WriteLine($"\nO número sorteado foi: {resultadoComputador}");

        posicaoComputador += resultadoComputador;

        Console.WriteLine($"• O computador está na posição: {posicaoComputador} de {limiteLinhaChegada}");

        if (posicaoComputador == 5 || posicaoComputador == 10 || posicaoComputador == 15 || posicaoComputador == 25)
        {

          Console.WriteLine($"\n>> EVENTO: Avanço de {bonusAvancoExtra} casas!");
          posicaoComputador += bonusAvancoExtra;

          Console.WriteLine($"• Agora o computador está na posição {posicaoComputador} de {limiteLinhaChegada}");

        }

        else if (posicaoComputador == 7 || posicaoComputador == 13 || posicaoComputador == 20)
        {

          Console.WriteLine($"\n>> EVENTO: Recuo de {penalidadeRecuo} casas!");
          posicaoComputador -= penalidadeRecuo;

          Console.WriteLine($"• Agora o computador está na posição {posicaoComputador} de {limiteLinhaChegada}");

        }

        if (posicaoComputador >= limiteLinhaChegada)
        {

          Console.WriteLine("\n>> Que pena! O computador alcançou a linha de chegada.");
          jogoEstaEmAndamento = false;

        }

        Console.Write("\nPressione ENTER para continuar...");
        Console.ReadLine();

      }

      Console.Write("\nDeseja continuar? [s/N]: ");
      string? opcaoContinuar = Console.ReadLine()?.ToUpper();

      if (opcaoContinuar != "S")
        break;

    }

  }

}