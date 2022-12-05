namespace AdventOfCode2022
{
    internal class Day1Puzzle
    {

        public Day1Puzzle()
        {
            List<int> inputList = new();
            string file = @"C:\Code\Advent of code 2022\input_day_1_Puzzle_1.txt";

            IEnumerable<string> fileInput = File.ReadLines(file);

            int counter = 0;
            foreach (string line in fileInput)
            {

                if (!string.IsNullOrWhiteSpace(line))
                {
                    counter += Convert.ToInt32(line);
                }
                else
                {
                    inputList.Add(counter);
                    counter = 0;
                }
            }

            Console.WriteLine("Puzzle 1");
            Console.WriteLine(inputList.Max());

            Console.WriteLine("Puzzle 2");
            Console.WriteLine(inputList.OrderByDescending(c => c).Take(3).Sum());
        }
    }
}