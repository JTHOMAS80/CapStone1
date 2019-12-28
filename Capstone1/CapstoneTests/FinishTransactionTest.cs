using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class FinishTransaction
    {
        //Note- smallest amount of change in system is .05(Nickel), .01(Pennies) are never introduced
        [TestMethod]
        public void FinishTransactionTestQuarter()
        {
            MoneyHandling moneyHandling = new MoneyHandling();

            var result = moneyHandling.FinishTransaction(.25M); // Act
            Assert.AreEqual("Your Change Is 1 Quarter(s) for a total of $0.25.", result, "Change should be correct and in fewest coins possible.");
        }
        [TestMethod]
        public void FinishTransactionTestDime()
        {
            MoneyHandling moneyHandling = new MoneyHandling();

            var result = moneyHandling.FinishTransaction(.10M); // Act
            Assert.AreEqual("Your Change Is 0 Quarter(s) and 1 Dime(s) for a total of $0.10.", result, "Change should be correct and in fewest coins possible.");
        }
        [TestMethod]
        public void FinishTransactionTestNickel()
        {
            MoneyHandling moneyHandling = new MoneyHandling();

            var result = moneyHandling.FinishTransaction(.05M); // Act
            Assert.AreEqual("Your Change Is 0 Quarter(s) and 1 Nickel(s) for a total of $0.05.", result, "Change should be correct and in fewest coins possible.");
        }
        [TestMethod]
        public void FinishTransactionTestOneEachCoin()
        {
            MoneyHandling moneyHandling = new MoneyHandling();

            var result = moneyHandling.FinishTransaction(.40M); // Act
            Assert.AreEqual("Your Change Is 1 Quarter(s), 1 Dime(s) and 1 Nickel(s) for a total of $0.40.", result, "Change should be correct and in fewest coins possible.");
        }
        [TestMethod]
        public void FinishTransactionTestLargeAmount()
        {
            MoneyHandling moneyHandling = new MoneyHandling();

            var result = moneyHandling.FinishTransaction(10.40M); // Act
            Assert.AreEqual("Your Change Is 41 Quarter(s), 1 Dime(s) and 1 Nickel(s) for a total of $10.40.", result, "Change should be correct and in fewest coins possible.");
        }
        //[TestMethod]
        
        //Dumb negative test, comes out with correct negative coins, though.
        //public void FinishTransactionTestNegativeAmount()
        //{
        //    MoneyHandling moneyHandling = new MoneyHandling();

        //    var result = moneyHandling.FinishTransaction(-10.40M); // Act
        //    Assert.AreEqual("Your Change Is 41 Quarter(s), 1 Dime(s) and 1 Nickel(s) for a total of $10.40.", result, "Change should be correct and in fewest coins possible.");
        //}
    }
}
