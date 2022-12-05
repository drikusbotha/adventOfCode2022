namespace AdventOfCode2022
{
    internal class Day3Puzzle
    {

        public Day3Puzzle()
        {
            string file = @"C:\Code\Advent of code 2022\input_day_3_Puzzle.txt";

            IEnumerable<string> fileInput = File.ReadLines(file);

            int priority = 0;
            foreach (string line in fileInput)
            {
                priority += GetPriority(GetCommonElementForLine(line));
            }

            Console.WriteLine("Puzzle 1");
            Console.WriteLine(priority);
            List<string> newList = new List<string>();
            newList.AddRange(fileInput);

            int start = 0;
            priority = 0;
            while (start < newList.Count)
            {
                List<string> records = newList.GetRange(start, 3);

                priority += GetPriority(GetCommonElementForCollection(records));

                start += 3;
            }

            Console.WriteLine("Puzzle 2");
            Console.WriteLine(priority);
        }

        private int GetPriority(char commonElement)
        {
            if (commonElement <= 90)
                return commonElement - 38;
            else return commonElement - 96;
        }

        private char GetCommonElementForLine(string line)
        {
            char[] compartmentLeft = line.Substring(0, line.Length / 2).ToCharArray();
            char[] compartmentRight = line.Substring((line.Length / 2), line.Length / 2).ToCharArray();

            IEnumerable<char> commonElement = compartmentLeft.Intersect(compartmentRight);

            return commonElement.FirstOrDefault();
        }

        private char GetCommonElementForCollection(List<string> records)
        {
            char[] t1 = records[0].ToCharArray();
            char[] t2 = records[1].ToCharArray();
            char[] t3 = records[2].ToCharArray();

            return t1.Intersect(t2).Intersect(t3).FirstOrDefault();
        }
    }
}