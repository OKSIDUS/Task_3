namespace Task_3
{
    internal class GameResult
    {
        private readonly int _countOfArguments;

        public GameResult(int countOfArguments)
        {
            _countOfArguments = countOfArguments;
        }
        public void CheckWinner(string userMove, int computerMove)
        {
            int numberOfAction = Convert.ToInt32(userMove);

            decimal mathFloor = Math.Floor((decimal)(_countOfArguments / 2));
            int result = Math.Sign(((numberOfAction - 1) - computerMove + _countOfArguments + mathFloor) % _countOfArguments - mathFloor);

            GetMessage(result);
            
        }

        private void GetMessage(int result)
        {
            GameResultList gameResult = (GameResultList)result;
            Console.WriteLine(gameResult.ToString());
        }
    }
}
