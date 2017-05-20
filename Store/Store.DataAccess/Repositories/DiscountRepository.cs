using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DataAccess.ViewModels;

namespace Store.DataAccess.Repositories
{
    public class DiscountRepository
    {
        public string AddDiscount(DiscountViewModel discount)
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
                        command.CommandText = "EXEC dbo.addDiscount @Name=@param0, @DateFrom = @param1, @DateTo = @param2, @Value = @param3";

                        command.Parameters.AddWithValue("@param0", discount.Name );
                        command.Parameters.AddWithValue("@param1", discount.DateFrom );
                        command.Parameters.AddWithValue("@param2", discount.DateTo );
                        command.Parameters.AddWithValue("@param3", discount.Value);
                        try
                        {
                            command.ExecuteNonQuery();
                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            return "NIe udało się dodać produktu" + ex.Message.ToString();
                        }
                    }
                }
            }
            return "Zniżka dodana pomyślnie";
        }

        public IEnumerable<DiscountViewModel> GetDiscounts()
        {

            List<DiscountViewModel> products = new List<DiscountViewModel>();

            using (SqlConnection conn = new SqlConnection(ConnectionString._connString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT DiscountId, Name, DateFrom, DateTo, Value FROM DBO.Discounts", conn))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        DateTime dateFrom = reader.GetDateTime(2);
                        DateTime dateTo= reader.GetDateTime(3);
                        decimal value = reader.GetDecimal(4);

                        products.Add(new DiscountViewModel() { DiscountId = id, Name = name, DateFrom = dateFrom, DateTo = dateTo, Value = value });
                    }
                }
            }

            return products;
        }

    }
}
