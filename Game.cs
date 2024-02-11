namespace Task_3
{
    internal class Game
    {
        private readonly string[] gameArgs;
        private readonly string _secretKey;
        private HMACCalculator? hmac;
        private readonly int countOfArguments;
        private int computerMove;
        public Game(string[] gameArgs)
        {
            this.gameArgs = gameArgs;
            countOfArguments = gameArgs.Length;
            SecretKeyGenerator secretKey = new();
            _secretKey = secretKey.GenerateSecretKey();
        }


        public void Start()
        {
            

            while (true)
            {
                ComputerMove();
                PrintActions();
                UserMove();
            }

        }

        private void ComputerMove()
        {
            var random = new Random();
            computerMove = random.Next(0, countOfArguments);
            hmac = new HMACCalculator(_secretKey);
            hmac.CalculateHMAC(gameArgs[computerMove]);
        }

        private void UserMove()
        {
            string? selectedAction = Console.ReadLine();
            CheckAction(selectedAction);
        }


        private void CheckAction(string? action)
        {
            var dataChecker = new DataChecker(gameArgs);


            if (dataChecker.IsValidNumberAction(action))
            {
                CheckMoveInput(action!);
            }
            else
            {
                CheckTableGeneration(action!);
            }
        }

        private void CheckTableGeneration(string action)
        {
            if (action == "?")
            {
                var tableGenerator = new TableGenerator(gameArgs);
                tableGenerator.Generate();
            }
            else
            {
                Console.WriteLine("incorrect action");
            }
        }

        private void CheckMoveInput(string action)
        {
            int numberOfMove = Convert.ToInt32(action);

            if (numberOfMove > 0)
            {
                var gameResult = new GameResult(countOfArguments);
                gameResult.CheckWinner(action!, computerMove);

                PrintUserMove(action);
                PrintPCMove(gameArgs[computerMove]);
                Console.WriteLine("HMAC Key: " + _secretKey+ '\n');
            }
            else
            {
                Console.WriteLine("Game over");
                Environment.Exit(0);
            }
        }

        private void PrintActions()
        {
            hmac!.PrintHMAC();
            for (int i = 0; i < countOfArguments; i++)
            {
                Console.WriteLine((i + 1) + " - " + gameArgs[i]);
            }

            Console.WriteLine("0 - exit\n? - help");
        }

        private void PrintUserMove(string move)
        {
            int indexOfMove = Convert.ToInt32(move);
            Console.WriteLine("Your move: " + gameArgs[indexOfMove - 1]);
        }

        private void PrintPCMove(string move)
        {
            Console.WriteLine("Computer move: " + move);
        }
    }
}
