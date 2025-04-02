using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics;
using System.Security.Cryptography;

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
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string insertQuery = "INSERT INTO [dbo].[Products] (code, name, amount, price, category, creationDate) VALUES (@code, @name, @amount, @price, @category, @creationDate)";
                string checkQuery = "SELECT 1 FROM [dbo].[Products] where code = @code";

                SqlCommand verificar = new SqlCommand(checkQuery, connection);
                verificar.Parameters.AddWithValue("@code", en.Code);
                object result = verificar.ExecuteScalar();
                int alredyExists = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;


                if (alredyExists > 0)
                {
                    throw new Exception("Ya existe un producto con este código.");
                }

                SqlCommand consulta = new SqlCommand(insertQuery, connection);
                consulta.Parameters.AddWithValue("@code", en.Code);
                consulta.Parameters.AddWithValue("@name", en.Name);
                consulta.Parameters.AddWithValue("@amount", en.Amount);
                consulta.Parameters.AddWithValue("@price", en.Price);
                consulta.Parameters.AddWithValue("@category", en.Category);
                consulta.Parameters.AddWithValue("@creationDate", en.CreationDate);
                consulta.ExecuteNonQuery();
                checkCreate = true;
                Console.WriteLine("Producto creado con éxito");
            }
            catch (SqlException e)
            {
                checkCreate = false;
                Console.WriteLine("Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }

            return checkCreate;
        }

        public bool Update(ENProduct en)
        {
            bool checkUpdate = false;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string updateQuery = "UPDATE [dbo].[Products] SET code = @code, name = @name, amount = @amount, price = @price, category = @category, creationDate = @creationDate WHERE code = @code";
                string checkQuery = "SELECT 1 FROM [dbo].[Products] where code = @code";

                SqlCommand verificar = new SqlCommand(checkQuery, connection);
                verificar.Parameters.AddWithValue("@code", en.Code);
                object result = verificar.ExecuteScalar();
                int doesNotExist = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;

                if (doesNotExist == 0)
                {
                    throw new Exception("No existe un producto con ese código");
                }


                SqlCommand consulta = new SqlCommand(updateQuery, connection);
                consulta.Parameters.AddWithValue("@code", en.Code);
                consulta.Parameters.AddWithValue("@name", en.Name);
                consulta.Parameters.AddWithValue("@amount", en.Amount);
                consulta.Parameters.AddWithValue("@price", en.Price);
                consulta.Parameters.AddWithValue("@category", en.Category);
                consulta.Parameters.AddWithValue("@creationDate", en.CreationDate);
                consulta.ExecuteNonQuery();
                checkUpdate = true;
                Console.WriteLine("Producto actualizado con éxito");
            }
            catch (SqlException e)
            {
                checkUpdate = false;
                Console.WriteLine("Error: " + e.Message);
            }
            catch (Exception e)
            {
                checkUpdate = false;
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                connection.Close();
            }

            return checkUpdate;
        }

        public bool Delete(ENProduct en)
        {
            bool checkDelete = false;
            SqlConnection connection = null;
            try
            {

                connection = new SqlConnection(constring);
                connection.Open();

                string deleteQuery = "DELETE FROM [dbo].[Products] WHERE code = @code";
                string checkQuery = "SELECT 1 FROM [dbo].[Products] where code = @code";

                SqlCommand verificar = new SqlCommand(checkQuery, connection);
                verificar.Parameters.AddWithValue("@code", en.Code);
                object result = verificar.ExecuteScalar();
                int doesNotExist = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;

                if (doesNotExist == 0)
                {
                    throw new Exception("No existe un producto con ese código");
                }

                SqlCommand consulta = new SqlCommand(deleteQuery, connection);
                consulta.Parameters.AddWithValue("@code", en.Code);
                consulta.ExecuteNonQuery();
                checkDelete = true;
            }
            catch (SqlException e) {
                checkDelete = false;
                Console.WriteLine("Error: ", e.Message);
            }
            catch (Exception e)
            {
                checkDelete = false;
                Console.WriteLine("Error: ", e.Message);
            }
            finally
            {
                connection.Close();
            }

            return checkDelete;
        }

        public bool Read(ENProduct en)
        {
            bool checkRead = true;
            SqlConnection connection = null;
            SqlDataReader busqueda = null;
            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string query = "SELECT * FROM [dbo].[Products] WHERE code = @code";
                SqlCommand consulta = new SqlCommand(query, connection);
                consulta.Parameters.AddWithValue("@code", en.Code);
                busqueda = consulta.ExecuteReader();


                if (busqueda.Read())
                {
                    en.Code = busqueda["code"].ToString();
                    en.Name = busqueda["name"].ToString();
                    en.Amount = Convert.ToInt32(busqueda["amount"]);
                    en.Price = Convert.ToSingle(busqueda["price"]);
                    en.Category = Convert.ToInt32(busqueda["category"]);
                    en.CreationDate = Convert.ToDateTime(busqueda["creationDate"]);
                }
                else checkRead = false;
            }
            catch (SqlException e)
            {
                checkRead = false;
                Console.WriteLine("Error: ", e.Message);
            }
            finally
            {
                busqueda.Close();
                connection.Close();
            }

            return checkRead;
        }

        public bool ReadFirst(ENProduct en)
        {
            bool checkReadFirst = true;
            SqlConnection connection = null;
            SqlDataReader busqueda = null;
            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string query = "SELECT TOP 1 * FROM [dbo].[Products] ORDER BY id";
                SqlCommand consulta = new SqlCommand(query, connection);
                consulta.Parameters.AddWithValue("@code", en.Code); 
                busqueda = consulta.ExecuteReader();


                if (busqueda.Read())
                {
                    en.Code = busqueda["code"].ToString();
                    en.Name = busqueda["name"].ToString();
                    en.Amount = Convert.ToInt32(busqueda["amount"]);
                    en.Price = Convert.ToSingle(busqueda["price"]);
                    en.Category = Convert.ToInt32(busqueda["category"]);
                    en.CreationDate = Convert.ToDateTime(busqueda["creationDate"]);
                }
                else checkReadFirst = false;
            }
            catch (SqlException e)
            {
                checkReadFirst = false;
                Console.WriteLine("Error: ", e.Message);
            }
            finally
            {
                busqueda.Close();
                connection.Close();
            }

            return checkReadFirst;
        }

        public bool ReadNext(ENProduct en)
        {
            bool checkReadNext = true;
            SqlConnection connection = null;
            SqlDataReader busqueda = null;
            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string query = "SELECT TOP 1 * FROM [dbo].[Products] WHERE id > @id ORDER BY id";
                SqlCommand consulta = new SqlCommand(query, connection);
                consulta.Parameters.AddWithValue("@code", en.Code);
                busqueda = consulta.ExecuteReader();


                if (busqueda.Read())
                {
                    en.Code = busqueda["code"].ToString();
                    en.Name = busqueda["name"].ToString();
                    en.Amount = Convert.ToInt32(busqueda["amount"]);
                    en.Price = Convert.ToSingle(busqueda["price"]);
                    en.Category = Convert.ToInt32(busqueda["category"]);
                    en.CreationDate = Convert.ToDateTime(busqueda["creationDate"]);
                }
                else checkReadNext = false;
            }
            catch (SqlException e)
            {
                checkReadNext = false;
                Console.WriteLine("Error: ", e.Message);
            }
            finally
            {
                busqueda.Close();
                connection.Close();
            }

            return checkReadNext;
        }

        public bool ReadPrev(ENProduct en)
        {
            bool checkReadPrev = true;
            SqlConnection connection = null;
            SqlDataReader busqueda = null;
            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string query = "SELECT TOP 1 * FROM [dbo].[Products] WHERE id < @id ORDER BY id";
                SqlCommand consulta = new SqlCommand(query, connection);
                consulta.Parameters.AddWithValue("@code", en.Code);
                busqueda = consulta.ExecuteReader();


                if (busqueda.Read())
                {
                    en.Code = busqueda["code"].ToString();
                    en.Name = busqueda["name"].ToString();
                    en.Amount = Convert.ToInt32(busqueda["amount"]);
                    en.Price = Convert.ToSingle(busqueda["price"]);
                    en.Category = Convert.ToInt32(busqueda["category"]);
                    en.CreationDate = Convert.ToDateTime(busqueda["creationDate"]);
                }
                else checkReadPrev = false;
            }
            catch (SqlException e)
            {
                checkReadPrev = false;
                Console.WriteLine("Error: ", e.Message);
            }
            finally
            {
                //busqueda.Close();
                connection.Close();
            }

            return checkReadPrev;
        }

    }
}
