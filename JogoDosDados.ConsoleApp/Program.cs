namespace JogoDosDados.ConsoleApp;

class Program
{
  static void Main(string[] args)
  {
    while (true)
    {
      StartGame();

      while (true)
      {
        Player.ExecuteTurn();

        if (Player.Won())
          break;

        Computer.ExecuteTurn();

        if (Computer.Won())
          break;
      }

      if (!ShouldContinue())
        break;
    }
  }

  static void StartGame()
  {
    Player.position = 0;
    Computer.position = 0;
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