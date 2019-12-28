using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Item
    {
        public string Slot { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 5;
        public string Type { get; set; }


        public Item(string[] properties)
        {
            Slot = properties[0];
            Name = properties[1];
            Price = decimal.Parse(properties[2]);
            Type = properties[3];

        }

    }
}
