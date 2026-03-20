using System.Security.Cryptography;
namespace JogoDosDados.ConsoleApp;

class Program
{
  static void Main(string[] args)
  {

    while (true)
    {

      Console.Write("\nDeseja continuar? [s/N]: ");
      string? userChoice = Console.ReadLine()?.ToUpper();

      if (userChoice != "S")
        break;
    }

  }
  static void ShowHeader()
  {
    Console.Clear();
    Console.WriteLine("=======================================");
    Console.WriteLine("JOGO CORRIDA DE DADOS");
    Console.WriteLine("=======================================");
  }

  static int ThrowDice()
  {
    int resultado = RandomNumberGenerator.GetInt32(1, 7);
    Console.WriteLine($"\nO número sorteado foi: {resultado}");

    return resultado;
  }

  static int UserTurn(int userPosition, int finishLine)
  {
    Console.WriteLine("\n---------- Rodada do Jogador ----------");

    Console.Write("\nPressione ENTER para lançar um dado...");
    Console.ReadLine();

    int playerRoll = ThrowDice();

    userPosition += playerRoll;

    Console.WriteLine($"• Você está na posição {userPosition} de {finishLine}");

    userPosition = ApplyEvents(finishLine, userPosition);

    return userPosition;
  }

  static int ComputerTurn(int computerPosition, int finishLine)
  {

    Console.WriteLine("\n-------- Rodada do Computador ---------");

    int computerRoll = ThrowDice();

    computerPosition += computerRoll;

    Console.WriteLine($"• O computador está na posição: {computerPosition} de {finishLine}");

    computerPosition = ApplyEvents(finishLine, computerPosition);

    return computerPosition;

  }

  static int ApplyEvents(int finishLine, int playerPosition)
  {
    const int extraAdvance = 3;
    const int setbackPenalty = 2;

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

  static void RunGame()
  {
    const int finishLine = 30;
    int userPosition = 0;
    int computerPosition = 0;

    ShowHeader();

    bool gameRunning = true;

    while (gameRunning)
    {

      ShowHeader();

      userPosition = UserTurn(userPosition, finishLine);

      if (userPosition >= finishLine)
      {
        Console.WriteLine("\n>> Parabéns! Você alcançou a linha de chegada.");
        gameRunning = false;

        continue;
      }

      Console.Write("\nPressione ENTER para continuar...");
      Console.ReadLine();

      computerPosition = ComputerTurn(computerPosition, finishLine);

      if (computerPosition >= finishLine)
      {
        Console.WriteLine("\n>> Que pena! O computador alcançou a linha de chegada.");
        gameRunning = false;

        continue;
      }

      Console.Write("\nPressione ENTER para continuar...");
      Console.ReadLine();

    }
  }

}