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

            var userChipsEnteredList = new List<ColorChip>();
            userChipsEnteredList.Add(new ColorChip(Color.Blue, Color.Yellow));
            userChipsEnteredList.Add(new ColorChip(Color.Red, Color.Green));
            userChipsEnteredList.Add(new ColorChip(Color.Yellow, Color.Red));
            userChipsEnteredList.Add(new ColorChip(Color.Orange, Color.Purple));
            businessLogic.VerifyChannel(userChipsEnteredList);
        }
    
    }
}
