namespace AdventOfCode2022
{
    internal class Day2Puzzle
    {

        public Day2Puzzle()
        {
            string file = @"C:\Code\Advent of code 2022\input_day_2_Puzzle.txt";

            IEnumerable<string> fileInput = File.ReadLines(file);

            int totalScore = 0;
            foreach (string line in fileInput)
            {
                string[] encoded = line.Split(' ');

                totalScore += CalculateRoundScore(encoded.FirstOrDefault(), encoded.LastOrDefault());
            }

            int totalScoreNewRules = 0;
            foreach (string line in fileInput)
            {
                string[] encoded = line.Split(' ');

                totalScoreNewRules += CalculateRoundScoreNewRules(encoded.FirstOrDefault(), encoded.LastOrDefault());
            }

            Console.WriteLine("Puzzle 1");
            Console.WriteLine(totalScore);

            Console.WriteLine("Puzzle 2");
            Console.WriteLine(totalScoreNewRules);
        }

        private enum Shape
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3
        }

        private enum RoundOutcome
        {
            Lose = 0,
            Draw = 3,
            Win = 6
        }

        private Shape DecodeInput(string input)
        {
            if (input == "A" || input == "X")
                return Shape.Rock;
            else if (input == "B" || input == "Y")
                return Shape.Paper;
            else //if (input == 'C' || input == 'Z')
                return Shape.Scissors;
        }

        private int CalculateRoundScore(string opponentPlayParam, string yourPlayParam)
        {
            Shape yourPlay = DecodeInput(yourPlayParam);
            Shape opponentPlay = DecodeInput(opponentPlayParam);

            RoundOutcome outcome = CalculateRoundOutcome(opponentPlay, yourPlay);

            int total = Convert.ToInt32(yourPlay) + Convert.ToInt32(outcome);

            return total;
        }
        private int CalculateRoundScoreNewRules(string opponentPlayParam, string yourPlayParam)
        {
            Shape opponentPlay = DecodeInput(opponentPlayParam);
            Shape yourPlay = WhatShouldYouPlay(opponentPlay, DecodeInput(yourPlayParam));

            RoundOutcome outcome = CalculateRoundOutcome(opponentPlay, yourPlay);

            int total = Convert.ToInt32(yourPlay) + Convert.ToInt32(outcome);

            return total;
        }

        private RoundOutcome CalculateRoundOutcome(Shape opponentPlay, Shape yourPlay)
        {
            //rock beats Scissors
            //paper beats rock
            //Scissors beats paper

            if (yourPlay.Equals(opponentPlay))
                return RoundOutcome.Draw;

            if (yourPlay.Equals(Shape.Rock) && opponentPlay.Equals(Shape.Scissors))
                return RoundOutcome.Win;

            if (yourPlay.Equals(Shape.Paper) && opponentPlay.Equals(Shape.Rock))
                return RoundOutcome.Win;

            if (yourPlay.Equals(Shape.Scissors) && opponentPlay.Equals(Shape.Paper))
                return RoundOutcome.Win;

            return RoundOutcome.Lose;
        }

        private Shape WhatShouldYouPlay(Shape opponentPlay, Shape yourPlay)
        {
            //draw
            if (yourPlay.Equals(Shape.Paper))
            {
                return opponentPlay;
            }
            else if (yourPlay.Equals(Shape.Rock)) //lose
            {
                if (opponentPlay.Equals(Shape.Rock))
                    return Shape.Scissors;
                else if (opponentPlay.Equals(Shape.Paper))
                    return Shape.Rock;
                else return Shape.Paper;
            }
            else //win
            {
                if (opponentPlay.Equals(Shape.Rock))
                    return Shape.Paper;
                else if (opponentPlay.Equals(Shape.Paper))
                    return Shape.Scissors;
                else return Shape.Rock;
            }
        }
    }
}