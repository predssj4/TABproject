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


        public string AddStore(StoreViewModel model)
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
                        command.CommandText =
                            "EXEC dbo.addStore @Name=@param1, @Street = @param2, @City = @param3, @Voivodeship = @param4";
                        command.Transaction = trans;

                        command.Parameters.AddWithValue("@param1", model.Name);
                        command.Parameters.AddWithValue("@param2", model.Street);
                        command.Parameters.AddWithValue("@param3", model.City);
                        command.Parameters.AddWithValue("@param4", model.Voivodeship);

                        try
                        {
                            command.ExecuteNonQuery();
                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            return "A new store can not be added:\n " + ex.Message.ToString();
                        }
                    }
                }
            }

            return "The new store added successfully";
        }

        public IEnumerable<StoreHouseViewModel> GetAllStoreHouses()
        {
            List<StoreHouseViewModel> storeHouses = new List<StoreHouseViewModel>();
            using (SqlConnection conn = new SqlConnection(ConnectionString._connString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT storehouseid, street, City, Voivodeship from dbo.StoreHouses";

                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        storeHouses.Add(new StoreHouseViewModel()
                        {
                            StoreHouseId = reader.GetInt32(0),
                            Street = reader.GetString(1),
                            City = reader.GetString(2),
                            Voivodeship = reader.GetString(3),

                        });
                    }
                }
            }

            return storeHouses;
        }

        public string BindStoreHouses(int storeId, List<int> storeHouses)
        {
            int storeHouseId = storeHouses[0];
            using (SqlConnection conn = new SqlConnection(ConnectionString._connString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conn;
                        command.Transaction = trans;
                        command.CommandType = CommandType.Text;
                        command.CommandText ="INSERT INTO dbo.StoresToStoreHouses (StoreId, StoreHouseId) values(@param1, @param2)";


                        command.Parameters.AddWithValue("@param1", storeId);
                        command.Parameters.AddWithValue("@param2", storeHouseId);


                        try
                        {
                            command.ExecuteNonQuery();
                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            return "The Storehouse couldn't be bound \n" + ex.Message.ToString();
                        }
                    }
                }
            }

            return "The Storehouse bound successfully";
        }
    }

}