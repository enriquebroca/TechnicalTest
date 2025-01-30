using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    public static class businessLogic
    {
        private static readonly Random _random = new Random();
        public static bool VerifyChannel(List<ColorChip> userChipsEnteredList)
        {


            // Find the first and last chip
            ColorChip firstChip = userChipsEnteredList.FirstOrDefault(c => c.StartColor == Color.Blue);
            ColorChip lastChip = userChipsEnteredList.FirstOrDefault(c => c.EndColor == Color.Green);

            if (firstChip == null || lastChip == null)
            {
                Console.WriteLine(Constants.ErrorMessage);
                return false;
            }

            // Dictionary to find chips by their starting color
            // Dictionary<Color, ColorChip> chipMap = userChipsEnteredList.ToDictionary(c => c.StartColor, c => c);
            Dictionary<Color, ColorChip> chipMap = userChipsEnteredList
                                                 .GroupBy(c => c.StartColor)
                                                 .ToDictionary(g => g.Key, g => g.First());

            //Ready to store the sorted sequence
            List<ColorChip> orderedChips = new List<ColorChip> { firstChip };
            Color currentColor = firstChip.EndColor;

            while (chipMap.ContainsKey(currentColor))
            {
                ColorChip nextChip = chipMap[currentColor];
                orderedChips.Add(nextChip);
                chipMap.Remove(currentColor);
                currentColor = nextChip.EndColor;

                if (currentColor == Color.Green) break;
            }

            if (orderedChips.Last().EndColor == Color.Green)
            {
                Console.WriteLine("✅ ¡Access allowed! Accepted combination:");
                Console.WriteLine("Blue -> " + string.Join(" -> ", orderedChips.Select(c => c.ToString())) + " -> Green");
                return false;
            }
            else
            {
                Console.WriteLine(Constants.ErrorMessage);
                return  true;
            }
        }
        public static Color GetRandomColor()
        {
            Array values = Enum.GetValues(typeof(Color));
            return (Color)values.GetValue(_random.Next(values.Length));
        }
    }
}
