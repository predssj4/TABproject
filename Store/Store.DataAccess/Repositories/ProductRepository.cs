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
                    command.CommandText = "EXEC dbo.addProduct @Name=@param1, @Description = @param2, @ProductTypeId = @param3, @Price = @param4";

                    command.Parameters.AddWithValue("@param1", product.Name);
                    command.Parameters.AddWithValue("@param2", product.Description);
                    command.Parameters.AddWithValue("@param3", product.ProductTypeId);
                    command.Parameters.AddWithValue("@param4", product.Price);

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
