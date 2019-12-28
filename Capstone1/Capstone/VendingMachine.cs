using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Capstone
{
    public class VendingMachine
    {
        //variables, classes, etc.
        private string directory = Environment.CurrentDirectory;
        private string filePath = @"..\..\..\..\VendingMachine.txt";
        private string salesFileName = @"..\..\..\..\...\..\SalesReport.txt";
        private string logFileName = @"..\..\..\..\...\..\LogReport.txt";
        private MoneyHandling moneyHandling = new MoneyHandling();
        private Dictionary<string, Item> Inventory = new Dictionary<string, Item>();

        public VendingMachine()
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (sr.EndOfStream == false)
                    {
                        string line = sr.ReadLine();
                        string[] itemProperties = line.Split("|");
                        Item ItemName = new Item(itemProperties);
                        Inventory.Add(ItemName.Slot, ItemName);
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Error Reading The File.");
                Console.ReadKey();
            }
        }

        public string GetInventoryDisplay()
        {
            string result = "";
            foreach (string key in Inventory.Keys)
            {
                if (Inventory[key].Quantity > 0)
                {
                    result += $" {Inventory[key].Slot} | {Inventory[key].Name} | {Inventory[key].Price} ";
                    result += "\n";
                }
                else
                {
                    result += $"{key} | SOLD OUT";
                    result += "\n";
                }
            }
            return result;
        }
        //writing out sales report and log files
        public void SalesReport()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(salesFileName, true))
                {
                    foreach (string key in Inventory.Keys)
                    {       
                        sw.WriteLine($"{Inventory[key].Name} | {5 - Inventory[key].Quantity}");
                    }
                    sw.WriteLine($"\n**TOTAL SALES**  {moneyHandling.MachineBalance.ToString("c", CultureInfo.GetCultureInfo("en-US"))}");
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Error Writing The File.");
                Console.ReadKey();
            }
        }
        public void LogReport()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(logFileName, false))
                {
                    foreach (string line in moneyHandling.logList)
                    {      
                        sw.WriteLine($"{line}");
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Error Writing The File.");
                Console.ReadKey();
            }
        }

        //methods to call information from Money Handling class

        public decimal UpdateBalanceDeposit(int depositAmount)
        {
            return moneyHandling.UpdateBalanceDeposit(depositAmount);
        }

        public string SelectedItem(string key)
        {
            try
            {
                return moneyHandling.SelectedItem(Inventory[key].Slot, Inventory);
            }
            catch(Exception)
            {
                return "\nThe slot does not exist.";
            }   
        }

        public bool UserHasMoney(decimal price, string key)
        {
            return moneyHandling.UserHasMoney(Inventory[key].Price);
        }

        public bool ItemExists(string key)
        {
            return moneyHandling.ItemExists(Inventory[key].Slot, Inventory);
        }

        public string SnackTypeMessage(string key)
        {
            return moneyHandling.SnackTypeMessage(Inventory[key].Type);
        }

        public string FinishTransaction(decimal change)
        {
            return moneyHandling.FinishTransaction(change);
        }
        public decimal UpdateBalance()
        {
            return moneyHandling.UserCurrentBalance;
        }
    }
}
