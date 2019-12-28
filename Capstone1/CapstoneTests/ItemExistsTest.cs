using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class ItemExistsTest
    {
            [TestMethod]
            public void ItemExistsTest1()
            {
                MoneyHandling moneyHandling = new MoneyHandling();

            //    Not sure on input formatting
            //    var result = moneyHandling.ItemExists("A1", { "A1", "Potato Crisps", 3.05, "5", " Chip"} ); // Act
            //    Assert.AreEqual("Your Change Is 1 Quarter(s) for a total of $0.25.", result, "Change should be correct and in fewest coins possible.");

            //    result string would be "$"\nPlease Insert Enough Money to Purchase the Item";" OR
            //    result = $"\n{SnackTypeMessage(keyType)}\n\nYour New Balance is {UserCurrentBalance.ToString("c", CultureInfo.GetCultureInfo("en-US"))}"; OR
            //    result = $"\nThe {key} does not exist.";
            //    Depending on Input

            }
    }
}
