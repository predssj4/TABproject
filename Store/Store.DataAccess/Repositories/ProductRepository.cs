using Store.DataAccess.ViewModels;
using System;
using System.Collections;
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

            return "Produkt Dodany";
        }

        public object DeleteProduct(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString._connString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "EXEC dbo.deleteProduct @productId=@id";

                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        return "Nie udało się usunąć produktu";
                    }

                }
            }

            return "Produkt usunięty pomyślnie";
        }

        public IEnumerable<ProductViewModel> GetProductsList()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            using (SqlConnection conn = new SqlConnection(ConnectionString._connString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM DBO.Products", conn))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);    // Weight int
                        string description = reader.GetString(2);  // Name string
                        int productTypeId = reader.GetInt32(3); // Breed string
                        decimal price = reader.GetDecimal(4);

                        products.Add(new ProductViewModel() { Id = id, Name = name, Description = description, ProductTypeId = productTypeId, Price = price });
                    }
                }
            }

            return products;
        }
    }
}
