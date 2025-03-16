using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ColorChip> chips = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Yellow),
                new ColorChip(Color.Red, Color.Green),
                new ColorChip(Color.Yellow, Color.Red),
                new ColorChip(Color.Orange, Color.Purple)
            };
            List<ColorChip> solution = FindValid(chips);
            if (solution != null && solution.Count > 0)
            {
                Console.Write("Blue ");
                foreach (var chip in solution)
                {
                    Console.Write("[" + chip + "] ");
                }
                Console.WriteLine("Green");
            }
            else
            {
                Console.WriteLine(Constants.ErrorMessage);
            }

        }
        static List<ColorChip> FindValid(List<ColorChip> chips)
        {
            List<ColorChip> bestSequence = new List<ColorChip>();
            FindSequence(new List<ColorChip>(), chips, Color.Blue, bestSequence);
            return bestSequence.Count > 0 ? bestSequence : null;
        }

        static void FindSequence(List<ColorChip> currentSequence, List<ColorChip> remainingChips, Color currentColor, List<ColorChip> bestSequence)
        {
            if (currentColor == Color.Green)
            {
                if (currentSequence.Count > bestSequence.Count)
                {
                    bestSequence.Clear();
                    bestSequence.AddRange(currentSequence);
                }
                return;
            }

            for (int i = 0; i < remainingChips.Count; i++)
            {
                ColorChip chip = remainingChips[i];
                if (chip.StartColor == currentColor)
                {
                    List<ColorChip> nextRemaining = new List<ColorChip>(remainingChips);
                    nextRemaining.RemoveAt(i);

                    List<ColorChip> nextSequence = new List<ColorChip>(currentSequence) { chip };
                    FindSequence(nextSequence, nextRemaining, chip.EndColor, bestSequence);
                }
            }
        }
    }
}
