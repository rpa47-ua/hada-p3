using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENCategory
    {
        private string name { get; set; }
        private int id { get; set; }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
   
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public ENCategory()
        {
            ID = 0;
            Name = "";
        }
        public ENCategory(string name, int id)
        {
            ID = id;
            Name = name;
        }
        public bool read()
        {
            try
            {
                CADCategory product = new CADCategory();
                return product.read(this);

            }
            catch 
            {
                return false;
            }
        }

        public List<ENCategory> readAll()
        {
            CADCategory producto = new CADCategory();
            return producto.readAll();
        }
    }
}
    

