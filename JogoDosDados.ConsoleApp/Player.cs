using System.Security.Cryptography;

class Player
{
  public string Name { get; }
  public int Position { get; private set; }
  private const int finishLine = 30;
  private const int extraAdvance = 3;
  private const int setbackPenalty = 2;

  public Player(string name)
  {
    Name = name;
    Position = 0;
  }

  public void ExecuteTurn()
  {
    do
    {
      ShowHeader();

      if (Name == "Jogador")
      {
        Console.Write("\nPressione ENTER para lançar um dado...");
        Console.ReadLine();
      }

      int diceRollResult = ThrowDice();

      Position += diceRollResult;

      ShowPosition();

      ApplyEvents();

      if (Won())
      {
        ShowVictoryMessage();
        break;
      }

      if (diceRollResult == 6)
      {
        Console.WriteLine("\n>> EVENTO: Rodada Extra! :)");

        if (Name == "Jogador")
        {
          Console.Write("\nPressione ENTER para lançar um dado...");
          Console.ReadLine();
        }

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

  private void ApplyEvents()
  {
    int[] advanceSpaces = { 5, 10, 15, 25 };
    int[] setbackSpaces = { 7, 13, 20 };

    if (advanceSpaces.Contains(Position))
    {
      Console.WriteLine($"\n>> EVENTO: Avanço de {extraAdvance} casas!");

      Position += extraAdvance;
      Console.WriteLine($"• Posição atual: {Position} de {finishLine}");
    }

    else if (setbackSpaces.Contains(Position))
    {
      Console.WriteLine($"\n>> EVENTO: Recuo de {setbackPenalty} casas!");

      Position -= setbackPenalty;
      Console.WriteLine($"• Posição atual: {Position} de {finishLine}");
    }
  }

  static int ThrowDice()
  {
    int result = RandomNumberGenerator.GetInt32(1, 7);
    Console.WriteLine($"\nO número sorteado foi: {result}");

    return result;
  }

  public bool Won()
  {
    return Position >= finishLine;
  }

  private void ShowHeader()
  {
    Console.Clear();
    Console.WriteLine("=======================================");
    Console.WriteLine("JOGO CORRIDA DE DADOS");
    Console.WriteLine("=======================================");

    Console.WriteLine($"\n---------- Rodada do {Name} ----------");
  }

  private void ShowVictoryMessage()
  {
    if (Name == "Jogador")
      Console.WriteLine("\n>> Parabéns! Você alcançou a linha de chegada.");
    else
      Console.WriteLine("\n>> Que pena! O computador ganhou.");
  }

  private void ShowPosition()
  {
    if (Name == "Jogador")
      Console.WriteLine($"• Você está na posição {Position} de {finishLine}");
    else
      Console.WriteLine($"• O computador está na posição {Position} de {finishLine}");
  }

}