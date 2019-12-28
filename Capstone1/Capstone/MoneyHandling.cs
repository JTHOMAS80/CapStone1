using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Capstone
{
    public class MoneyHandling
    {
        //Variables
        public decimal UserCurrentBalance { get; set; } = 0;
        public decimal MachineBalance { get; set; }

        private const decimal quarterValue = .25M;
        private const decimal dimeValue = .10M;
        private const decimal nickelValue = .05M;

        private int quarterAmount = 0;
        private int dimeAmount = 0;
        private int nickelAmount = 0;
        public List<string> logList = new List<string>();


        //Logic dealing with deposit and balance

        public decimal UpdateBalanceDeposit(int deposit)
        {
            UserCurrentBalance += deposit;
            //add the transaction for the log
            logList.Add($"{DateTime.UtcNow} FEED MONEY: {deposit.ToString("c", CultureInfo.GetCultureInfo("en-US"))} {UserCurrentBalance.ToString("c", CultureInfo.GetCultureInfo("en-US"))}");
            return UserCurrentBalance;
        }

        // Logic for item selection, existence, etc.
        public bool UserHasMoney(decimal price)
        {
            bool result = UserCurrentBalance > price;
            return result;
        }
        public bool ItemExists(string key, Dictionary<string, Item> inventory)
        {
            bool result = inventory.ContainsKey(key);
            return result;
        }
        public string SelectedItem(string key, Dictionary<string, Item> inventory)
        {
            string result = "";
            string keyName = inventory[key].Name;
            decimal keyPrice = inventory[key].Price;
            string keyType = inventory[key].Type;

            if (UserHasMoney(keyPrice) == false)
            {
                result = $"\nPlease Insert Enough Money to Purchase the Item";
            }
            else if (inventory[key].Quantity == 0)
            {            
                result = $"\nThe item in {key} is sold out";
            }
            else if (ItemExists(key, inventory))
            {
                string salesReportItem = $"{keyName}";

                UserCurrentBalance -= keyPrice;
                MachineBalance += keyPrice;
                inventory[key].Quantity --;
                //add the transaction for the log
                logList.Add($"{DateTime.UtcNow} {keyName} {key} {keyPrice.ToString("c", CultureInfo.GetCultureInfo("en-US"))} {UserCurrentBalance.ToString("c", CultureInfo.GetCultureInfo("en-US"))}");

                result = $"\n{SnackTypeMessage(keyType)}\n\nYour New Balance is {UserCurrentBalance.ToString("c", CultureInfo.GetCultureInfo("en-US"))}";
            }
            else
            {
                result = $"\nThe {key} does not exist.";
            }
            return result;
        }
        public string SnackTypeMessage(string keyType)
        {
            string type = keyType;
            string result = "";
            if(type == "Chip")
            {
                result = "Crunch Crunch, Yum!";
            }
            else if (type == "Candy")
            {
                result = "Munch Munch, Yum!";
            }
            else if (type == "Drink")
            {
                result = "Glug Glug, Yum!";
            }
            else if (type == "Gum")
            {
                result = "Chew Chew, Yum!";
            }
            return result;
        }

        //Logic for giving change back
        public string FinishTransaction(decimal change)
        {
            //variables
            string result = "";
            string totalChange = change.ToString("c", CultureInfo.GetCultureInfo("en-US"));
            quarterAmount = (int)(change / quarterValue);
            change -= quarterAmount * quarterValue;
            dimeAmount = (int)(change / dimeValue);
            change -= dimeAmount * dimeValue;
            nickelAmount = (int)(change / nickelValue);
            change -= nickelAmount * nickelValue;
            UserCurrentBalance = 0;
            //add the transaction for the log
            logList.Add($"{DateTime.UtcNow} GIVE CHANGE: {totalChange}");

            if (nickelAmount == 0 && dimeAmount == 0)
            {
                result = $"Your Change Is {quarterAmount} Quarter(s) For a Total of {totalChange}.";
            }
            else if (dimeAmount == 0)
            {
                result = $"Your Change Is {quarterAmount} Quarter(s) and {nickelAmount} Nickel(s) For a Total of {totalChange}.";
            }
            else if (nickelAmount == 0)
            {
                result = $"Your Change Is {quarterAmount} Quarter(s) and {dimeAmount} Dime(s) For a Total of {totalChange}.";
            }
            else
            {
                result = $"Your Change Is {quarterAmount} Quarter(s), {dimeAmount} Dime(s) and {nickelAmount} Nickel(s) For a Total of {totalChange}.";
            }
            return result;
        }

    }
}
