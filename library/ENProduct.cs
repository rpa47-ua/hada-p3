using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using System;

namespace library
{
    public class ENProduct
    {
        private string code;
        private string name;
        private int amount;
        private int category;
        private float price;
        private DateTime creationDate;

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
            Price = price;
            Category = category;
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
            return new CADProduct().Update(this);
        }

        public bool Delete()
        {
            return new CADProduct().Delete(this);
        }

        public bool Read()
        {
            return new CADProduct().Read(this);
        }

        public bool ReadFirst()
        {
            return new CADProduct().ReadFirst(this);
        }

        public bool ReadNext()
        {
            return new CADProduct().ReadNext(this);
        }

        public bool ReadPrev()
        {
            return new CADProduct().ReadPrev(this);
        }
    }
}



