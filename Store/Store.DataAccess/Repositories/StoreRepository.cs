using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Store.DataAccess.ViewModels;

namespace Store.DataAccess.Repositories
{
    public class StoreRepository
    {


        public IEnumerable<StoreIncomeViewModel> GetStoresIncome()
        {
            List<StoreIncomeViewModel> incomes = new List<StoreIncomeViewModel>();
            using (SqlConnection conn = new SqlConnection(ConnectionString._connString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "EXEC dbo.getStoresIncome";

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        incomes.Add(new StoreIncomeViewModel()
                        {
                            StoreId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Income = reader.GetDecimal(2)

                        });
                    }
                }
            }

            return incomes;

        }

        public IEnumerable<StoreIncomeDetailsViewModel> GetIncomeDetails(int id)
        {
            List<StoreIncomeDetailsViewModel> details = new List<StoreIncomeDetailsViewModel>();
            using (SqlConnection conn = new SqlConnection(ConnectionString._connString))
            {


                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "EXEC dbo.getIncomeDetailsForStore @id=@StoreId";

                    command.Parameters.AddWithValue("@StoreId", id);


                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        details.Add(new StoreIncomeDetailsViewModel()
                        {
                            OrderId = reader.GetInt32(0),
                            ProductName = reader.GetString(1),
                            Price = reader.GetDecimal(2)
                        });
                    }
                }
            }

            return details;
        }


        public IEnumerable<StoreViewModel> GetStores()
        {
            List<StoreViewModel> stores = new List<StoreViewModel>();
            using (SqlConnection conn = new SqlConnection(ConnectionString._connString))
            {


                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "EXEC dbo.getStores";

                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        stores.Add(new StoreViewModel()
                        {
                            StoreId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Street = reader.GetString(2),
                            City = reader.GetString(3),
                            Voivodeship = reader.GetString(4),
                            AmountOfStoreHouses = reader.GetInt32(5)
                        });
                    }
                }
            }

            return stores;
        }


    }
}