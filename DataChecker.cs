namespace Task_3
{
    public class DataChecker
    {
        private readonly string[]? data;

        public DataChecker(string[]? data)
        {
            if (data == null)
            {
                data = Array.Empty<string>();
            }


            this.data = data;
        }

        public bool IsValidData()
        {
            return ValidateCountItems() && IsHasDublicate();
        }

        private bool ValidateCountItems()
        {
            if (data!.Length < 3)
            {
                Console.WriteLine("the number of moves must be equal or greater than 3");
                return false;
            }

            if (data.Length % 2 == 0)
            {
                Console.WriteLine("the number of moves must be odd");
                return false;
            }

            return true;
        }

        private bool IsHasDublicate()
        {
            if (data!.Distinct().Count() != data!.Length)
            {
                Console.WriteLine("The moves should not be repeated");
                return false;
            }

            return true;

        }

        public bool IsValidNumberAction(string? action)
        {
            if (string.IsNullOrEmpty(action))
            {
                Console.WriteLine("You must choose an action!!!");
                return false;
            }


            if (int.TryParse(action, out int numberOfAction))
            {
                return numberOfAction <= data!.Length;
            }

            return false;
        }
    }
}
