﻿using System;
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
    }
}
