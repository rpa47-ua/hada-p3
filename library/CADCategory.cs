using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class CADCategory
    {
        private string constring = ConfigurationManager.ConnectionStrings["Database"].ToString();

        public bool Read(ENCategory en)
        {
            bool checkRead = false;
            SqlConnection connection = null;
            SqlDataReader busqueda = null;
            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string query = "SELECT name FROM [dbo].[Categories] WHERE id = @id";
                SqlCommand consulta = new SqlCommand(query, connection);
                consulta.Parameters.AddWithValue("@id", en.Id);
                busqueda = consulta.ExecuteReader();

                if (busqueda.Read())
                {
                    en.Name = busqueda["name"].ToString();
                    checkRead = true;
                }
            }
            catch (SqlException e)
            {
                checkRead = false;
                Console.WriteLine("Error: ", e.Message);
            }
            finally
            {
                connection.Close();
                busqueda.Close();
            }
            return checkRead;
        }

        public List<ENCategory> ReadAll()
        {
            List<ENCategory> categories = new List<ENCategory>();
            SqlConnection connection = null;
            SqlDataReader busqueda = null;

            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string query = "SELECT id, name FROM [dbo].[Categories]";
                SqlCommand consulta = new SqlCommand(query, connection);
                busqueda = consulta.ExecuteReader();

                while (busqueda.Read())
                {
                    ENCategory category = new ENCategory();
                    category.Id = Convert.ToInt32(busqueda["id"]);
                    category.Name = busqueda["name"].ToString();
                    categories.Add(category);

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error: ", e.Message);
            }
            finally
            {
                connection.Close();
                busqueda.Close();
            }
            
            return categories;
        }
    }
}
