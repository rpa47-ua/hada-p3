using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace library
{
    public class CADProduct ///Mirar a ver cambiar a public
    {
        private string constring;

        public CADProduct()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public bool Create(ENProduct en)
        {
            bool checkCreate = false;
            try
            {
                SqlConnection connection = null;
                connection = new SqlConnection(constring);
                connection.Open();

                //Mirar a ver query con valores que no son strings, ToString() ??
                string query = "INSERT [dbo].[Products] (code, name, amount, price, category, creationDate) " +
                    "VALUES ('" + en.code + "', '" + en.name + "', " + en.amount + ", " + en.price + ", " + en.category + ", " + en.creationDate + ")";
                SqlCommand consulta = new SqlCommand(query, connection);
                consulta.ExecuteNonQuery();
                checkCreate = true;
                connection.Close();
            }
            catch(SqlException e)
            {
                checkCreate = false;
                Console.WriteLine("Error: ", e.ToString());
            }
            //Mirar Exception e

            return checkCreate;
        }

        public bool Update(ENProduct en)
        {
            bool checkUpdate = false;
            try
            {
                SqlConnection connection = null;
                connection = new SqlConnection(constring);
                connection.Open();

                //Mirar a ver query con valores que no son strings, ToString() ??
                string query = "UPDATE [dbo].[Products] " +
                       "SET code = '" + en.code + "' , name = '" en.name + "' , amount = " en.amount + ", price = " en.price + ", category = " en.category + ", creationDate = " en.creationDate + "WHERE id = " + en.id +"";
                SqlCommand consulta = new SqlCommand(query, connection);
                consulta.ExecuteNonQuery();
                checkUpdate = true;
                connection.Close();
            }
            catch (SqlException e)
            {
                checkUpdate = false;
                Console.WriteLine("Error: ", e.ToString());
            }
            //Mirar Exception e

            return checkUpdate;
        }

        public bool Delete(ENProduct en)
        {
            bool checkDelete = false;
            try
            {
                SqlConnection connection = null;
                connection = new SqlConnection(constring);
                connection.Open();

                //Mirar a ver query con valores que no son strings, ToString() ??
                string query = "DELETE from [dbo].[Products] where id = " + en.id "";
                SqlCommand consulta = new SqlCommand(query, connection);
                consulta.ExecuteNonQuery();
                checkDelete = true;
                connection.Close();
            }
            catch (SqlException e) {
                checkDelete = false;
                Console.WriteLine("Error: ", e.ToString());
            }
            //Mirar Exception e

            return checkDelete;
        }
    }
}
