using ConsoleTables;

namespace Task_3
{
    internal class TableGenerator
    {
        private readonly string[] _tableData;
        private ConsoleTable? consoleTable;

        public TableGenerator(string[] tableData)
        {
            _tableData = tableData;
        }


        public void Generate()
        {
            GenerateHeader();
            GenerateRows();

            consoleTable!.Write();
        }


        private void GenerateHeader()
        {
            string[] header = new string[_tableData.Length + 1];
            header[0] = "PC/USER";
            int i = 1;
            foreach (var data in _tableData)
            {
                header[i] = data.ToString();
                i++;
            }

            consoleTable = new ConsoleTable(header);
        }

        private void GenerateRows()
        {
            for (int i = 0; i < _tableData.Length; i++)
            {
                string[] row = new string[_tableData.Length + 1];
                row[0] = _tableData[i];
                for(int j = 1; j <= _tableData.Length; j++)
                {
                    int result = CalculateMoveResult(j - 1, i, _tableData.Length);
                    GameResultList gameResult = (GameResultList)result;
                    row[j] = gameResult.ToString();
                }
                consoleTable!.AddRow(row);
            }
        }

        private int CalculateMoveResult(int numberOfMove, int currentMove, int totalNumber)
        {
            decimal mathFloor = Math.Floor((decimal)(totalNumber / 2));
            return Math.Sign((numberOfMove - currentMove + totalNumber + mathFloor) % totalNumber - mathFloor);
        }
    }
}
