using System.Security.Cryptography;
namespace JogoDosDados.ConsoleApp;

class Program
{
  static void Main(string[] args)
  {
    const int finishLine = 30;
    const int extraAdvance = 3;
    const int setbackPenalty = 2;

    RunGame(finishLine, extraAdvance, setbackPenalty);
  }

  static void RunGame(int finishLine, int extraAdvance, int setbackPenalty)
  {

    while (true)
    {
      int userPosition = 0;
      int computerPosition = 0;

      while (true)
      {
        userPosition = UserTurn(userPosition, finishLine, extraAdvance, setbackPenalty);

        if (userPosition >= finishLine)
          break;

        computerPosition = ComputerTurn(computerPosition, finishLine, extraAdvance, setbackPenalty);

        if (computerPosition >= finishLine)
          break;
      }

      if (!ShouldContinue())
        break;
    }

  }

  static int UserTurn(int userPosition, int finishLine, int extraAdvance, int setbackPenalty)
  {
    do
    {
      ShowHeader("Jogador");

      Console.Write("\nPressione ENTER para lançar um dado...");
      Console.ReadLine();

      int playerRoll = ThrowDice();

      userPosition += playerRoll;

      Console.WriteLine($"• Você está na posição {userPosition} de {finishLine}");

      userPosition = ApplyEvents(finishLine, userPosition, extraAdvance, setbackPenalty);

      if (userPosition >= finishLine)
      {
        Console.WriteLine("\n>> Parabéns! Você alcançou a linha de chegada.");

        Console.Write("\nPressione ENTER para continuar...");
        Console.ReadLine();

        break;
      }

      if (playerRoll == 6)
      {
        Console.WriteLine("\n>> EVENTO: Rodada Extra! :)");

        Console.Write("\nPressione ENTER para continuar...");
        Console.ReadLine();

        continue;
      }

      else
      {
        Console.Write("\nPressione ENTER para continuar...");
        Console.ReadLine();
        break;
      }

    } while (true);

    return userPosition;
  }

  static int ComputerTurn(int computerPosition, int finishLine, int extraAdvance, int setbackPenalty)
  {
    do
    {

      ShowHeader("Computador");

      int playerRoll = ThrowDice();

      computerPosition += playerRoll;

      Console.WriteLine($"• O computador está na posição: {computerPosition} de {finishLine}");

      computerPosition = ApplyEvents(finishLine, computerPosition, extraAdvance, setbackPenalty);

      if (computerPosition >= finishLine)
      {
        Console.WriteLine("\n>> Que pena! O computador ganhou.");

        break;
      }

      if (playerRoll == 6)
      {
        Console.WriteLine("\n>> EVENTO: Rodada Extra! :)");

        continue;
      }

      else
      {
        Console.Write("\nPressione ENTER para continuar...");
        Console.ReadLine();

        break;
      }

    } while (true);

    return computerPosition;
  }

  static void ShowHeader(string playerName)
  {
    Console.Clear();
    Console.WriteLine("=======================================");
    Console.WriteLine("JOGO CORRIDA DE DADOS");
    Console.WriteLine("=======================================");

    Console.WriteLine($"\n---------- Rodada do {playerName} ----------");
  }

  static int ThrowDice()
  {
    int resultado = RandomNumberGenerator.GetInt32(1, 7);
    Console.WriteLine($"\nO número sorteado foi: {resultado}");

    return resultado;
  }

  static int ApplyEvents(int finishLine, int playerPosition, int extraAdvance, int setbackPenalty)
  {

    int[] advanceSpaces = { 5, 10, 15, 25 };
    int[] setbackSpaces = { 7, 13, 20 };

    if (advanceSpaces.Contains(playerPosition))
    {
      Console.WriteLine($"\n>> EVENTO: Avanço de {extraAdvance} casas!");
      playerPosition += extraAdvance;

      Console.WriteLine($"• Posição atual: {playerPosition} de {finishLine}");
    }

    else if (setbackSpaces.Contains(playerPosition))
    {
      Console.WriteLine($"\n>> EVENTO: Recuo de {setbackPenalty} casas!");
      playerPosition -= setbackPenalty;

      Console.WriteLine($"• Posição atual: {playerPosition} de {finishLine}");
    }

    return playerPosition;

  }

  static bool ShouldContinue()
  {
    Console.Write("\nDeseja continuar? [s/N]: ");
    string? userChoice = Console.ReadLine()?.ToUpper();

    if (userChoice != "S")
      return false;

    return true;
  }
}