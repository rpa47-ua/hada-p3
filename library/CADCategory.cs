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
            try
            {
                SqlConnection connection = null;
                connection = new SqlConnection(constring);
                connection.Open();

                string query = "SELECT name FROM [dbo].[Categories] WHERE id = " + en.id;
                SqlCommand consulta = new SqlCommand(query, connection);
                SqlDataReader busqueda = consulta.ExecuteReader();

                if (busqueda.Read())
                {
                    en.name = busqueda["name"].ToString();
                    checkRead = true;
                }

                connection.Close();
            }
            catch (SqlException e)
            {
                checkRead = false;
                Console.WriteLine("Error: ", e.Message);
            }
            return checkRead;
        }

        public List<ENCategory> ReadAll()
        {
            List<ENCategory> categories = new List<ENCategory>();
            try
            {
                SqlConnection connection = null;
                connection = new SqlConnection(constring);
                connection.Open();

                string query = "SELECT id, name FROM [dbo].[Categories]";
                SqlCommand consulta = new SqlCommand(query, connection);
                SqlDataReader busqueda = consulta.ExecuteReader();

                while (busqueda.Read())
                {
                    categories.Add(new ENCategory(busqueda["id"], busqueda["name"].ToString()));
                }

                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error: ", e.Message);
            }
            return categories;
        }
    }
}
