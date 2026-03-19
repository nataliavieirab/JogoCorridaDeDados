using System.Security.Cryptography;

namespace JogoDosDados.ConsoleApp;

class Program
{
  static void Main(string[] args)
  {
    while (true)
    {

      Console.Clear();
      Console.WriteLine("---------------------------------");
      Console.WriteLine("Jogo dos Dados");
      Console.WriteLine("---------------------------------");

      Console.Write("Pressione ENTER para lançar um dado...");
      Console.ReadLine();

      int resultado = RandomNumberGenerator.GetInt32(1, 7);

      Console.WriteLine("---------------------------------");
      Console.WriteLine($"O número sorteado foi: {resultado}");
      Console.WriteLine("---------------------------------");

      Console.Write("Deseja continuar? [s/N]: ");
      string? opcaoContinuar = Console.ReadLine()?.ToUpper();

      if (opcaoContinuar != "S")
        break;

    }
  }
}
