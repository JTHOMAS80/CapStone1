using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class UserHasMoneyTest
    {
            [TestMethod]
            public void UserHasMoneyTest1()
            {
                //Arrange
                MoneyHandling moneyHandling = new MoneyHandling();

                var result = moneyHandling.UserHasMoney(1M); // Act
                Assert.AreEqual(false, result, "Result will be bool true or false based on UserBalance < ItemPrice or reverse.");
            }
            //Test passed as bool default is false, not sure how to enter ItemPRice for Comparison.
        }
}
