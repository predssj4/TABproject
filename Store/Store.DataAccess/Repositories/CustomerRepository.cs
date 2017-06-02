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
    public class CustomerRepository
    {
        public CustomerDetailsViewModel GetCustomerDetails(int customerId)
        {
            List<OrderViewModel> ordersOfCustomer = new List<OrderViewModel>();

            using (SqlConnection conn = new SqlConnection(ConnectionString._connString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "EXEC dbo.getCustomerOrders @CustomerId = @cusId";

                    command.Parameters.AddWithValue("@cusId", customerId);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ordersOfCustomer.Add(new OrderViewModel()
                        {
                            OrderId = (int)reader["OrderId"],
                            CustomerId = (int)reader["CustomerId"],
                            StoreName = (string)reader["StoreName"],
                            PaymentType = (string)reader["PaymentType"],
                            OrderDate = (DateTime)reader["OrderDate"],
                            OrderSum = (decimal)reader["OrderSum"]

                        });
                    }
                }
            }

            var details = new CustomerDetailsViewModel();


            using (SqlConnection conn = new SqlConnection(ConnectionString._connString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "EXEC dbo.getCustomerDetails @CustomerId=@param0";

                    command.Parameters.AddWithValue("@param0", customerId);

                    conn.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();

                        details.Description = (string) reader["Description"];
                        details.FullName = (string) reader["FullName"];
                        details.SumOfOrders = (decimal) reader["sumOfOrders"];

                    }
                }
            }

            details.Orders = ordersOfCustomer;


            return details;

        }

        public IEnumerable<CustomerViewModel> GetCustomersList()
        {
            List<CustomerViewModel> customers = new List<CustomerViewModel>();

            using (SqlConnection conn = new SqlConnection(ConnectionString._connString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "EXEC dbo.getCustomersList";

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        customers.Add(new CustomerViewModel()
                        {
                            CustomerId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            LastName = reader.GetString(2),
                            BirthDate = reader.GetDateTime(3),
                            Address = reader.GetString(4),
                            Gender = reader.GetString(5)

                        });
                    }
                }
            }
            return customers;
        }
    }
}
