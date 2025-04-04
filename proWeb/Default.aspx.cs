using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            try
            {
                CADCategory cadCategory = new CADCategory();
                List<ENCategory> categories = cadCategory.ReadAll();

                DropDownList.DataSource = categories;
                DropDownList.DataTextField = "Name";  // Corresponde a ENCategory.Name
                DropDownList.DataValueField = "Id";   // Corresponde a ENCategory.Id
                DropDownList.DataBind();
            }
            catch (Exception ex)
            {
                outputMssg.Text = "Error loading categories: " + ex.Message;
            }
        }

        protected void DropDownListSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DropDownList.SelectedValue))
            {
                string selectedId = DropDownList.SelectedValue;
                string selectedName = DropDownList.SelectedItem.Text;
            }
        }


        private bool ValidateProductData(string code, string name, int amount, float price, out string errorMessage)
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
            if (price < 0 || price > 9999.99)
            {
                errorMessage = "El precio debe estar entre 0 y 9999,99";
                return false;
            }

            //REPASAR mirar a ver etiqueta si es en campo individual o salida por consola

            return true;
        }
        protected void onCreate(object sender, EventArgs e)
        {
            //Poner try cath en todos los metodos

            if (string.IsNullOrWhiteSpace(text_Code.Text) || string.IsNullOrWhiteSpace(text_Name.Text) || string.IsNullOrWhiteSpace(text_Amount.Text) ||string.IsNullOrWhiteSpace(text_Price.Text) || string.IsNullOrWhiteSpace(text_CreationDate.Text))
            {
                outputMssg.Text = "Todos los campos son obligatorios";
                return;
            }

            if (!int.TryParse(text_Amount.Text, out int amount))
            {
                outputMssg.Text = "La cantidad debe ser un número entero válido";
                return;
            }

            if (!float.TryParse(text_Price.Text, out float price))
            {
                outputMssg.Text = "El precio debe ser un número válido";
                return;
            }

            if (!DateTime.TryParseExact(text_CreationDate.Text, "dd/MM/yyyy hh:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime creationDate))
            {
                outputMssg.Text = "La fecha debe tener el formato dd/MM/yyyy hh:mm:ss";
                return;
            }

            string code = text_Code.Text.Trim();
            string name = text_Name.Text.Trim();
            int category = DropDownList.SelectedIndex + 1;
            DateTime cretionDate;
            DateTime.TryParseExact(text_CreationDate.Text, "dd/MM/yyyy hh:mm:ss", null, System.Globalization.DateTimeStyles.None, out cretionDate);

            if (!ValidateProductData(code, name, amount, price, out string validateError))
            {
                outputMssg.Text = validateError; //Sale el pirmero que este mal ?
                return;
            }
            else
            {
                ENProduct product = new ENProduct(code, name, amount, price, category, cretionDate);
                CADProduct cadProduct = new CADProduct();
                bool result = cadProduct.Create(product);

                if (result) outputMssg.Text = "Producto creado con éxito";
                else outputMssg.Text = "Error al crear el producto";
            }
        }

        protected void onUpdate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(text_Code.Text) || string.IsNullOrWhiteSpace(text_Name.Text) || string.IsNullOrWhiteSpace(text_Amount.Text) || string.IsNullOrWhiteSpace(text_Price.Text) || string.IsNullOrWhiteSpace(text_CreationDate.Text))
            {
                outputMssg.Text = "Todos los campos son obligatorios";
                return;
            }

            if (!int.TryParse(text_Amount.Text, out int amount))
            {
                outputMssg.Text = "La cantidad debe ser un número entero válido";
                return;
            }

            if (!float.TryParse(text_Price.Text, out float price))
            {
                outputMssg.Text = "El precio debe ser un número válido";
                return;
            }

            if (!DateTime.TryParseExact(text_CreationDate.Text, "dd/MM/yyyy hh:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime creationDate))
            {
                outputMssg.Text = "La fecha debe tener el formato dd/MM/yyyy hh:mm:ss";
                return;
            }

            string code = text_Code.Text.Trim();
            string name = text_Name.Text.Trim();
            int category = DropDownList.SelectedIndex + 1;
            DateTime cretionDate;
            DateTime.TryParseExact(text_CreationDate.Text, "dd/MM/yyyy hh:mm:ss", null, System.Globalization.DateTimeStyles.None, out cretionDate);

            if (!ValidateProductData(code, name, amount, price, out string validateError))
            {
                outputMssg.Text = validateError;
                return;
            }
            else
            {
                ENProduct product = new ENProduct(code, name, amount, price, category, cretionDate);
                CADProduct cadProduct = new CADProduct();
                bool result = cadProduct.Update(product);

                if (result) outputMssg.Text = "Producto actualizado con éxito";
                else outputMssg.Text = "Error al acutaliar el producto";
            }

        }

        protected void onDelete(object sender, EventArgs e)
        {
            
            string code = text_Code.Text.Trim();

            if (string.IsNullOrEmpty(code))
            {
                outputMssg.Text = "Introduzca un código válido";
                return;
            }


            ENProduct product = new ENProduct();
            product.Code = code;    
            CADProduct cadProduct = new CADProduct();
            bool result =  cadProduct.Delete(product);

            if (result) outputMssg.Text = "Producto borrado con éxito";
            else outputMssg.Text = "Error al borrar el producto";
         
        }

        protected void onRead(object sender, EventArgs e)
        {
            string code = text_Code.Text.Trim();

            if(string.IsNullOrEmpty(code))
            {
                outputMssg.Text = "Introduzca un código válido";
                return;
            }

            ENProduct product = new ENProduct();
            CADProduct cADProduct = new CADProduct();
            product.Code = code;
            bool result = cADProduct.Read(product);

            if(result)
            {
                text_Name.Text = product.Name;
                text_Amount.Text = product.Amount.ToString();
                DropDownList.SelectedIndex = product.Category - 1;
                text_Price.Text = product.Price.ToString();
                text_CreationDate.Text = product.CreationDate.ToString();
                outputMssg.Text = "Producto encontrado";
            }
            else
            {
                outputMssg.Text = "Producto no encontrado";
            }
        }
        protected void onReadFirst(object sender, EventArgs e)
        {
            ENProduct product = new ENProduct();
            CADProduct cADProduct = new CADProduct();
            bool result = cADProduct.ReadFirst(product);

            if (result)
            {
                text_Code.Text = product.Code;
                text_Name.Text = product.Name;
                text_Amount.Text = product.Amount.ToString();
                DropDownList.SelectedIndex = product.Category - 1;
                text_Price.Text = product.Price.ToString();
                text_CreationDate.Text = product.CreationDate.ToString("dd/MM/yyyy hh:mm:ss");
                outputMssg.Text = "Primer producto encontrado";
            }
            else
            {
                outputMssg.Text = "No hay productos en la base de datos";
            }
        }

        protected void onReadPrev(object sender, EventArgs e) 
        {
            string code = text_Code.Text.Trim();

            if (string.IsNullOrEmpty(code))
            {
                outputMssg.Text = "Introduzca un código válido";
                return;
            }

            ENProduct product = new ENProduct();
            CADProduct cADProduct = new CADProduct();
            product.Code = code;
            bool result = cADProduct.ReadPrev(product);

            if (result)
            {
                text_Code.Text = product.Code;
                text_Name.Text = product.Name;
                text_Amount.Text = product.Amount.ToString();
                DropDownList.SelectedIndex = product.Category - 1;
                text_Price.Text = product.Price.ToString();
                text_CreationDate.Text = product.CreationDate.ToString("dd/MM/yyyy hh:mm:ss");
                outputMssg.Text = "Producto anterior encontrado";
            }
            else
            {
                outputMssg.Text = "No hay productos anteriores";
            }
        }

        protected void onReadNext(object sender, EventArgs e)
        {
            string code = text_Code.Text.Trim();

            if (string.IsNullOrEmpty(code))
            {
                outputMssg.Text = "Introduzca un código válido";
                return;
            }

            ENProduct product = new ENProduct();
            CADProduct cADProduct = new CADProduct();
            product.Code = code;
            bool result = cADProduct.ReadNext(product);

            if (result)
            {
                text_Code.Text = product.Code;
                text_Name.Text = product.Name;
                text_Amount.Text = product.Amount.ToString();
                DropDownList.SelectedIndex = product.Category - 1;
                text_Price.Text = product.Price.ToString();
                text_CreationDate.Text = product.CreationDate.ToString("dd/MM/yyyy hh:mm:ss");
                outputMssg.Text = "Producto siguiente encontrado";
            }
            else
            {
                outputMssg.Text = "No hay más productos";
            }
        }
    }
}