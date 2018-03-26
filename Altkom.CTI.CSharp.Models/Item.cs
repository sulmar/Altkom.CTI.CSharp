using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.CTI.CSharp.Models
{
    public abstract class Item : Base
    {
        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public Item(string name, decimal unitPrice)
        {
            this.Name = name;
            this.UnitPrice = unitPrice;
        }
    }

    public class Product : Item
    {
        public Product(string name, decimal unitPrice, string color)
            : base(name, unitPrice)
        {
            this.Color = color;
            // ...
        }

        public Product(string name, decimal unitPrice)
             : this(name, unitPrice, "Transparent")
        {
        }

        public string Color { get; set; }
    }

    public class Service : Item
    {
        public Service(string name, decimal unitPrice) 
            : base(name, unitPrice)
        {
        }
    }

}
