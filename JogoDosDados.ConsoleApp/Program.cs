namespace JogoDosDados.ConsoleApp;

class Program
{
  static void Main(string[] args)
  {
    while (true)
    {
      Player user = new Player("Jogador");
      Player computer = new Player("Computador");

      while (true)
      {
        user.ExecuteTurn();

        if (user.Won())
          break;

        computer.ExecuteTurn();

        if (computer.Won())
          break;
      }

      if (!ShouldContinue())
        break;
    }
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