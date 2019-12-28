using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class UpdateBalanceDepositTest
    {
        [TestMethod]
        public void UpdateBalanceDeposit1()
        {
            MoneyHandling moneyHandling = new MoneyHandling();

            var result = moneyHandling.UpdateBalanceDeposit(1); // Act
            Assert.AreEqual(1, result, "Result will be deposit amount as formula will always be  0 + deposit");
        }
        [TestMethod]
        public void UpdateBalanceDeposit10()
        {
            MoneyHandling moneyHandling = new MoneyHandling();

            var result = moneyHandling.UpdateBalanceDeposit(10); // Act
            Assert.AreEqual(10, result, "Result will be deposit amount as formula will always be  0 + deposit");
        }
    }
}
