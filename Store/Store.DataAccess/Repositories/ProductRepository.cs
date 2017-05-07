using Store.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess
{
    public class ProductRepository
    {

       
        public string AddProduct(ProductViewModel product)
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString._connString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO klant(klant_id,naam,voornaam) 
                            VALUES(@param1,@param2,@param3)";

                    //command.Parameters.AddWithValue("@param1", klantId);
                    //command.Parameters.AddWithValue("@param2", klantNaam);
                    //command.Parameters.AddWithValue("@param3", klantVoornaam);

                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        return "Nie udało się dodać produktu";
                    }
                    
                }
            }

            return "";
        }

        
    }
}
