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
            Code = string.Empty;
            Name = string.Empty;
            Amount = 0;
            Price = 0.0f;
            Category = 0;
            CreationDate = DateTime.Now;

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
        public bool Create()
        {
            try
            {
                CADProduct product = new CADProduct();
                return product.Create(this);

            }
            catch
            {
                return false;
            }
        }
        public bool Update()
        {
            try
            {
                CADProduct product = new CADProduct();
                return product.Update(this);
            }
            catch
            {
                return false;
            }


        }
        public bool Delete()
        {
            try
            {
                CADProduct product = new CADProduct();
                return product.Delete(this);
            }
            catch
            {
                return false;
            }
        }
        public bool Read()
        {
            try
            {
                CADProduct product = new CADProduct();
                return product.Read(this);

            }
            catch
            {
                return false;
            }
        }
        public bool ReadFirst()
        {
            try
            {
                CADProduct product = new CADProduct();
                return product.ReadFirst(this);
            }
            catch
            {
                return false;
            }
        }
        public bool ReadNext()
        {
            try
            {
                CADProduct product = new CADProduct();
                return product.ReadNext(this);
            }
            catch
            {
                return false;
            }
        }
        public bool ReadPrev()
        {
            try
            {
                CADProduct product = new CADProduct();
                return product.ReadPrev(this);
            }
            catch
            {
                return false;
            }
        }
    }
 }



