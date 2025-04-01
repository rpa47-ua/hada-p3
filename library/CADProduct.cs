using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

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
                Console.WriteLine("Error: ", e.Message);
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
                Console.WriteLine("Error: ", e.Message());
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
                Console.WriteLine("Error: ", e.Message());
            }
            //Mirar Exception e

            return checkDelete;
        }

        public bool Read(ENProduct en)
        {
            bool checkRead = true;

            try
            {
                SqlConnection connection = null;
                connection = new SqlConnection(constring);
                connection.Open();

                //Mirar a ver query con valores que no son strings, ToString() ??
                string query = "SELECT * FROM [dbo].[Products] WHERE id =" + en.id;
                SqlCommand consulta = new SqlCommand(query, connection);
                SqlDataReader busqueda = consulta.ExecuteReader();
                busqueda.Read();

                if (busqueda["id"].ToString() == en.id)
                {
                    en.code = busqueda["code"]; //Son varchar hace falta, ToString();
                    en.name = busqueda["name"]; //Son varchar hace falta, ToString();
                    en.amount = busqueda["amount"].ToString();
                    en.price = busqueda["price"].ToString();
                    en.category = busqueda["category"].ToString();
                    en.creationDate = busqueda["creationDate"].ToString();
                }
                else checkRead = false;

                busqueda.Close();  
                connection.Close();
            }
            catch (SqlException e)
            {
                checkRead = false;
                Console.WriteLine("Error: ", e.Message);  
            }

            return checkRead;
        }

        public bool ReadFirst(ENProduct en)
        {
            bool checkReadFirst = true;

            try
            {
                SqlConnection connection = null;
                connection = new SqlConnection(constring);
                connection.Open();

                //Mirar a ver query con valores que no son strings, ToString() ??
                string query = "SELECT * FROM [dbo].[Products]";
                SqlCommand consulta = new SqlCommand(query, connection);
                SqlDataReader busqueda = consulta.ExecuteReader();
                busqueda.Read();

                en.code = busqueda["code"]; //Son varchar hace falta, ToString();
                en.name = busqueda["name"]; //Son varchar hace falta, ToString();
                en.amount = busqueda["amount"].ToString();
                en.price = busqueda["price"].ToString();
                en.category = busqueda["category"].ToString();
                en.creationDate = busqueda["creationDate"].ToString();

                busqueda.Close();
                connection.Close();
            }
            catch (SqlException e)
            {
                checkReadFirst = false;
                Console.WriteLine("Error: ", e.Message);
            }

            return checkReadFirst;
        }

        public bool ReadNext(ENProduct en)
        {
            bool checkReadNext = true;
            bool encontrado = false;

            try
            {
                SqlConnection connection = null;
                connection = new SqlConnection(constring);
                connection.Open();

                //Mirar a ver query con valores que no son strings, ToString() ??
                string query = "SELECT * FROM [dbo].[Products]";
                SqlCommand consulta = new SqlCommand(query, connection);
                SqlDataReader busqueda = consulta.ExecuteReader();
                busqueda.Read();

                while (busqueda.Read())
                {
                    if (encontrado)
                    {
                        en.code = busqueda["code"]; //Son varchar hace falta, ToString();
                        en.name = busqueda["name"]; //Son varchar hace falta, ToString();
                        en.amount = busqueda["amount"].ToString();
                        en.price = busqueda["price"].ToString();
                        en.category = busqueda["category"].ToString();
                        en.creationDate = busqueda["creationDate"].ToString();
                        break;
                    }
                    else if (en.id == busqueda["id"])
                    {
                        encontrado = true;
                    }
                }

                busqueda.Close();
                connection.Close();
            }
            catch (SqlException e)
            {
                checkReadNext = false;
                Console.WriteLine("Error: ", e.Message);
            }

            return checkReadNext;
        }

        public bool ReadNext(ENProduct en)
        {
            bool checkReadNext = true;
            bool encontrado = false;

            try
            {
                SqlConnection connection = null;
                connection = new SqlConnection(constring);
                connection.Open();

                //Mirar a ver query con valores que no son strings, ToString() ??
                string query = "SELECT * FROM [dbo].[Products]";
                SqlCommand consulta = new SqlCommand(query, connection);
                SqlDataReader busqueda = consulta.ExecuteReader();
                busqueda.Read();

                while (busqueda.Read())
                {
                    if (encontrado)
                    {
                        en.code = busqueda["code"]; //Son varchar hace falta, ToString();
                        en.name = busqueda["name"]; //Son varchar hace falta, ToString();
                        en.amount = busqueda["amount"].ToString();
                        en.price = busqueda["price"].ToString();
                        en.category = busqueda["category"].ToString();
                        en.creationDate = busqueda["creationDate"].ToString();
                        break;
                    }
                    else if (en.id == busqueda["id"])
                    {
                        encontrado = true;
                    }
                }

                busqueda.Close();
                connection.Close();
            }
            catch (SqlException e)
            {
                checkReadNext = false;
                Console.WriteLine("Error: ", e.Message);
            }

            return checkReadNext;
        }

        public bool ReadPrev(ENProduct en)
        {
            bool checkReadPrev = false;

            try
            {
                SqlConnection connection = null;
                connection = new SqlConnection(constring);
                connection.Open();

                //Mirar a ver query con valores que no son strings, ToString() ??
                string query = "SELECT * FROM [dbo].[Products]";
                SqlCommand consulta = new SqlCommand(query, connection);
                SqlDataReader busqueda = consulta.ExecuteReader();
                busqueda.Read();

                ENProduct temp = new ENProduct();
                temp.code = busqueda["code"];
                temp.name = busqueda["name"];
                temp.amount = busqueda["amount"].ToString();
                temp.price = busqueda["price"].ToString();
                temp.category = busqueda["category"].ToString();
                temp.creationDate = busqueda["creationDate"].ToString();

                while (busqueda.Read() && !checkReadPrev)
                {
                    if (busqueda["id"] = en.id)
                    {
                        checkReadPrev = true; 
                        break;
                    }
                    
                temp.code = busqueda["code"];
                temp.name = busqueda["name"];
                temp.amount = busqueda["amount"].ToString();
                temp.price = busqueda["price"].ToString();
                temp.category = busqueda["category"].ToString();
                temp.creationDate = busqueda["creationDate"].ToString();

                }

                en.code = temp.code;
                en.name = temp.name;
                en.amount = temp.amount;
                en.price = temp.price;
                en.category = temp.category;
                en.creationDate = temp.creationDate;

                busqueda.Close();
                connection.Close();
            }
            catch (SqlException e)
            {
                checkReadPrev = false;
                Console.WriteLine("Error: ", e.Message);
            }

            return checkReadPrev;
        }
    }
}
