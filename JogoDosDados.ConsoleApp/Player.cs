using System.Security.Cryptography;

static class Player
{

  public static int position = 0;
  private const int finishLine = 30;
  private const int extraAdvance = 3;
  private const int setbackPenalty = 2;

  public static void ExecuteTurn()
  {
    do
    {
      ShowHeader();

      Console.Write("\nPressione ENTER para lançar um dado...");
      Console.ReadLine();

      int diceRollResult = ThrowDice();

      position += diceRollResult;

      Console.WriteLine($"• Você está na posição {position} de {finishLine}");

      position = ApplyEvents();

      if (position >= finishLine)
      {
        Console.WriteLine("\n>> Parabéns! Você alcançou a linha de chegada.");

        break;
      }

      if (diceRollResult == 6)
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
  }

  public static bool Won()
  {
    return position >= finishLine;
  }

  private static void ShowHeader()
  {
    Console.Clear();
    Console.WriteLine("=======================================");
    Console.WriteLine("JOGO CORRIDA DE DADOS");
    Console.WriteLine("=======================================");

    Console.WriteLine("\n---------- Rodada do Jogador ----------");
  }

  static int ThrowDice()
  {
    int result = RandomNumberGenerator.GetInt32(1, 7);
    Console.WriteLine($"\nO número sorteado foi: {result}");

    return result;
  }

  static int ApplyEvents()
  {

    int[] advanceSpaces = { 5, 10, 15, 25 };
    int[] setbackSpaces = { 7, 13, 20 };

    if (advanceSpaces.Contains(position))
    {
      Console.WriteLine($"\n>> EVENTO: Avanço de {extraAdvance} casas!");
      position += extraAdvance;

      Console.WriteLine($"• Posição atual: {position} de {finishLine}");
    }

    else if (setbackSpaces.Contains(position))
    {
      Console.WriteLine($"\n>> EVENTO: Recuo de {setbackPenalty} casas!");
      position -= setbackPenalty;

      Console.WriteLine($"• Posição atual: {position} de {finishLine}");
    }

    return position;

  }

}