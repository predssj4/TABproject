﻿using Store.DataAccess.ViewModels;
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
                    catch(Exception ex)
                    {
                        return "Nie udało się dodać produktu: "+ex.Message.ToString();
                    }

                }
            }

            return "Produkt Dodany";
        }

        public string EditProduct(ProductViewModel product)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString._connString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;

                    command.CommandText = "EXEC dbo.editProduct @Id=@param0, @Name=@param1, @Description = @param2, @ProductTypeId = @param3, @Price = @param4";

                    command.Parameters.AddWithValue("@param0", product.Id);
                    command.Parameters.AddWithValue("@param1", product.Name);
                    command.Parameters.AddWithValue("@param2", product.Description);
                    command.Parameters.AddWithValue("@param3", product.ProductTypeId);
                    command.Parameters.AddWithValue("@param4", product.Price);

                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return "Nie udało się edytować produktu: " + ex.Message.ToString();
                    }
                }
            }

            return "Produkt edytowany pomyślnie";
        }

        public ProductDetailsViewModel GetDetails(int id)
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString._connString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "EXEC dbo.getProductDetails @Id=@param0";

                    command.Parameters.AddWithValue("@param0", id);

                    conn.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();

                        var result = new ProductDetailsViewModel()
                        {
                            Id = (int) reader["ProductId"],
                            Description = (string) reader["Description"],
                            ProductType = (string) reader["ProductType"],
                            Name = (string) reader["Name"],
                            Price = (decimal) reader["Price"],
                            SumForAllOrders = (decimal) reader["OrdersSum"],
                            HowManyTimesOrdered = (int) reader["AmountOfOrders"],
                            ProductTypeId = (int)reader["ProductTypeId"]
                        };

                        return result;
                    }
                }
            }
        }

        public object DeleteProduct(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString._connString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conn;
                        command.CommandType = CommandType.Text;
                        command.Transaction = trans;
                        command.CommandText = "EXEC dbo.deleteProduct @productId=@param0";

                        command.Parameters.AddWithValue("@param0", id);
                        try
                        {
                            command.ExecuteNonQuery();
                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            return "Nie udało się usunąć produktu" + ex.Message.ToString();
                        }
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

        public ProductViewModel GetProduct(int productId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString._connString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "EXEC dbo.getProduct @Id=@param0";

                    command.Parameters.AddWithValue("@param0", productId);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();

                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string description = reader.GetString(2);
                        int productTypeId = reader.GetInt32(3);
                        decimal price = reader.GetDecimal(4);

                        return new ProductViewModel() { Id = id, Name = name, Description = description, ProductTypeId = productTypeId, Price = price };
                    }

                    
                }
            }

        }
    }
}
