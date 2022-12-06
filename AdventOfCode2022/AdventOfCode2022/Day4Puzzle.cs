namespace AdventOfCode2022
{
    internal class Day4Puzzle
    {

        public Day4Puzzle()
        {
            string file = @"C:\Code\Advent of code 2022\input_day_4_Puzzle.txt";

            IEnumerable<string> fileInput = File.ReadLines(file);

            int counter = 0;
            foreach (string line in fileInput)
            {
                counter += IsFullyContained(line, true) ? 1 : 0;
            }

            Console.WriteLine("Puzzle 1");
            Console.WriteLine(counter);

            counter = 0;
            foreach (string line in fileInput)
            {
                counter += IsFullyContained(line, false) ? 1 : 0;
            }

            Console.WriteLine("Puzzle 1");
            Console.WriteLine(counter);
        }

        private bool IsFullyContained(string line, bool fullyContains)
        {
            string[] split = line.Split(",");
            string[] elf1 = split[0].Split("-");
            string[] elf2 = split[1].Split("-");

            List<int> elf1Expanded = new();
            int starting = Convert.ToInt32(elf1[0]);
            while (starting <= Convert.ToInt32(elf1[1]))
            {
                elf1Expanded.Add(starting);
                starting++;
            }

            List<int> elf2Expanded = new();
            int starting2 = Convert.ToInt32(elf2[0]);
            while (starting2 <= Convert.ToInt32(elf2[1]))
            {
                elf2Expanded.Add(starting2);
                starting2++;
            }
            if (fullyContains)
                return elf1Expanded.All(item => elf2Expanded.Contains(item)) || elf2Expanded.All(item => elf1Expanded.Contains(item));
            else
                return elf1Expanded.Any(item => elf2Expanded.Contains(item)) || elf2Expanded.Any(item => elf1Expanded.Contains(item));
        }
    }
}