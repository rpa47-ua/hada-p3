using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace library
{
    public class ENProduct
    {
        private string code { get; set; }
        private string name { get; set; }
        private int amount { get; set; }
        private int category { get; set; }
        private float price { get; set; }
        private DateTime creationDate { get; set; }

        public string Code
        {
            get { return code; }
            set { code = value; }

        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public int Category
        {
            get { return category; }
            set { category = value; }
        }
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }
        public ENProduct()
        {

        }
        public ENProduct(string code, string name, int amount, float price, int category, DateTime creationDate)
        {
            Code = code;
            Name = name;
            Amount = amount;
            Category = category;
            Price = price;
            CreationDate = creationDate;

        }

    }
}
