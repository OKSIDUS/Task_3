using System.Security.Cryptography;

namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dataChecker = new DataChecker(args);
            if (dataChecker.IsValidData())
            {
                var game = new Game(args);
                game.Start();
            }

        }
    }
}
