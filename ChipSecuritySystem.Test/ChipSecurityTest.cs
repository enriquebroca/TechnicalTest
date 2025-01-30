using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChipSecuritySystem.Test
{
    [TestClass]
    public class ChipSecurityTest
    {
        [TestMethod]
        public void TestRandomColorChip()
        {
            var userChipsEnteredList = new List<ColorChip>();
            userChipsEnteredList.Add(new ColorChip(Color.Blue, businessLogic.GetRandomColor()));
            userChipsEnteredList.Add(new ColorChip(businessLogic.GetRandomColor(), businessLogic.GetRandomColor()));
            userChipsEnteredList.Add(new ColorChip(businessLogic.GetRandomColor(), businessLogic.GetRandomColor()));
            userChipsEnteredList.Add(new ColorChip(businessLogic.GetRandomColor(), Color.Green));
            bool chinpsVerify = businessLogic.VerifyChannel(userChipsEnteredList);
            Assert.IsTrue(chinpsVerify);

        }
    }
}
