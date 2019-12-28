using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class SnackTypeTest
    {
        [TestMethod]
        public void SnackTypeMessageTestChip()
        {
            //Arrange
            MoneyHandling moneyHandling = new MoneyHandling();

            var result = moneyHandling.UserHasMoney("Chip"); // Act
            Assert.AreEqual("Crunch Crunch, Yum!", result, "Snack types should have seperate output messages.");
        }

        [TestMethod]
        public void SnackTypeMessageTestCandy()
        {
            MoneyHandling moneyHandling = new MoneyHandling();

            var result = moneyHandling.UserHasMoney("Candy"); // Act
            Assert.AreEqual("Munch Munch, Yum!", result, "Snack types should have seperate output messages.");
        }
        [TestMethod]
        public void SnackTypeMessageTestDrink()
        {
            MoneyHandling moneyHandling = new MoneyHandling();

            var result = moneyHandling.UserHasMoney("Drink"); // Act
            Assert.AreEqual("Glug Glug, Yum!", result, "Snack types should have seperate output messages.");
        }
        [TestMethod]
        public void SnackTypeMessageTestGum()
        {
            MoneyHandling moneyHandling = new MoneyHandling();

            var result = moneyHandling.UserHasMoney("Gum"); // Act
            Assert.AreEqual("Chew Chew, Yum!", result, "Snack types should have seperate output messages.");
        }
    }
}
