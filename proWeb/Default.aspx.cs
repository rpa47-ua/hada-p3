using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //outputMssge = ""; ??
        }


        private bool ValidateProductData(string code, string name, int amount, decimal price, out string errorMessage)
        {
            errorMessage = "";

            // Validación de Code
            if (string.IsNullOrEmpty(code) || code.Length > 16)
            {
                errorMessage = "El codigo debe presentar entre 1 y 16 carácteres";
                return false;
            }

            // Validación de Name
            if (string.IsNullOrEmpty(name) || name.Length > 32)
            {
                errorMessage = "El nombre debe estar formado por un maximo de 32 carácteres";
                return false;
            }

            // Validación de Amount
            if (amount < 0 || amount > 9999)
            {
                errorMessage = "La cantida debe estar entre 0 y 9999";
                return false;
            }

            // Validación de Price
            if (price < 0 || price > 9999.99m)
            {
                errorMessage = "El precio debe estar entre 0 y 9999,99";
                return false;
            }

            //REPASAR mirar a ver etiqueta si es en campo individual o salida por consola

            return true;
        }
        protected void onCreate(object sender, EventArgs e)
        {
            string code = text_Code.Text.Trim();
            string name = text_Name.Text.Trim();
            int amount = int.Parse(text_Amount.Text);
            decimal price = decimal.Parse(text_Price.Text);
            DateTime cretionDate;
            DateTime.TryParseExact(text_CreationDate.Text, "dd/MM/yyyy hh:mm:ss", null, System.Globalization.DateTimeStyles.None, out cretionDate);
            int category = DropDownList.SelectedIndex;

            if (!ValidateProductData(code, name, amount, price, out string validateError))
            {
                outputMssg.Text = validateError; //Sale el pirmero que este mal
                return;
            }
            else
            {
                // A completar cuando tengamos clases CADProduct, ENProduct
            }
        }

        protected void onUpdate(object sender, EventArgs e)
        {
            string code = text_Code.Text.Trim();
            string name = text_Name.Text.Trim();
            int amount = int.Parse(text_Amount.Text);
            decimal price = decimal.Parse(text_Price.Text);
            DateTime cretionDate;
            DateTime.TryParseExact(text_CreationDate.Text, "dd/MM/yyyy hh:mm:ss", null, System.Globalization.DateTimeStyles.None, out cretionDate);
            int category = DropDownList.SelectedIndex;

            if (!ValidateProductData(code, name, amount, price, out string validateError))
            {
                outputMssg.Text = validateError; //Sale el pirmero que este mal
                return;
            }
            else
            {
                // A completar cuando tengamos clases CADProduct, ENProduct
            }

        }

        protected void onDelete(object sender, EventArgs e)
        {
            string code = text_Code.Text.Trim();
            string name = text_Name.Text.Trim();
            int amount = int.Parse(text_Amount.Text);
            decimal price = decimal.Parse(text_Price.Text);
            DateTime cretionDate;
            DateTime.TryParseExact(text_CreationDate.Text, "dd/MM/yyyy hh:mm:ss", null, System.Globalization.DateTimeStyles.None, out cretionDate);
            int category = DropDownList.SelectedIndex;

            if (!ValidateProductData(code, name, amount, price, out string validateError))
            {
                outputMssg.Text = validateError; //Sale el pirmero que este mal
                return;
            }
            else
            {
                // A completar cuando tengamos clases CADProduct, ENProduct
            }
        }

        protected void onRead(object sender, EventArgs e)
        {
            // A completar cuando tengamos clases CADProduct, ENProduct
        }
        protected void onReadFirst(object sender, EventArgs e)
        {
            // A completar cuando tengamos clases CADProduct, ENProduct
        }

        protected void onReadPrev(object sender, EventArgs e) 
        {
            // A completar cuando tengamos clases CADProduct, ENProduct
        }

        protected void onReadNext(object sender, EventArgs e)
        {
            // A completar cuando tengamos clases CADProduct, ENProduct
        }
    }
}