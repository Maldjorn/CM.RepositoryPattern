using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CM.Customers.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        readonly string connectionString;
        public CustomerRepository()
        {
            connectionString = @"Data Source=DESKTOP-JDONGM6\SQLEXPRESS;Database=CustomerLib_Timoschenko;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
        public CustomerRepository(string ConnectionString)
        {
            connectionString = ConnectionString;
        }
        public void Create(Customer entity)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO dbo.[Customers](first_name,last_name,phone_number,email,notes,total_purchases_amount)VALUES(@firstName,@lastName,@phoneNumber,@email,@notes,@totalPurchasesAmount)", connection);
                var FistNameParam = new SqlParameter("@firstName", SqlDbType.VarChar, 50)
                {
                    Value = entity.firstName
                };
                var LastNameParam = new SqlParameter("@lastName", SqlDbType.VarChar, 50)
                {
                    Value = entity.lastName
                };
                var PhoneNumberParam = new SqlParameter("@phoneNumber", SqlDbType.VarChar, 20)
                {
                    Value = entity.phoneNumber
                };
                var EmailParam = new SqlParameter("@email", SqlDbType.VarChar, 50)
                {
                    Value = entity.email
                };
                var NotesParam = new SqlParameter("@notes", SqlDbType.VarChar, 100)
                {
                    Value = entity.notes
                };
                var TotalPurchaseAmount = new SqlParameter("@totalPurchasesAmount", SqlDbType.Decimal)
                {
                    Value = entity.totalPurchaseAmount
                };
                command.Parameters.Add(FistNameParam);
                command.Parameters.Add(LastNameParam);
                command.Parameters.Add(PhoneNumberParam);
                command.Parameters.Add(EmailParam);
                command.Parameters.Add(NotesParam);
                command.Parameters.Add(TotalPurchaseAmount);
                command.ExecuteNonQuery();
            }

        }

        public void Delete(int entityCode)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "DELETE FROM dbo.[Customers] WHERE customer_ID = @customerID", connection);
                var customerIDParam = new SqlParameter("@customerID", SqlDbType.Int)
                {
                    Value = entityCode
                };
                command.Parameters.Add(customerIDParam);
                command.ExecuteNonQuery();
            }
        }

        public Customer Read(int entityCode)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT * FROM dbo.[Customers] WHERE customer_ID = @customerID", connection);
                var customerIDParam = new SqlParameter("@customerID", SqlDbType.Int)
                {
                    Value = entityCode
                };
                command.Parameters.Add(customerIDParam);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Customer
                        {
                            firstName = reader["first_name"].ToString(),
                            lastName = reader["last_name"].ToString(),
                            email = reader["email"].ToString(),
                            notes = reader["notes"].ToString(),
                            phoneNumber = reader["phone_number"].ToString(),
                            totalPurchaseAmount = Convert.ToDecimal(reader["total_purchases_amount"])
                        };
                    }
                    return new Customer();
                }
            }
        }

        public void Update(Customer entity)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE dbo.[Customers] SET first_name=@firstName, last_name=@lastName, phone_number=@phoneNumber, email=@email,notes = @notes,total_purchases_amount=@totalPurchasesAmount WHERE customer_ID = @customerID", connection);
                var FistNameParam = new SqlParameter("@firstName", SqlDbType.VarChar, 50)
                {
                    Value = entity.firstName
                };
                var LastNameParam = new SqlParameter("@lastName", SqlDbType.VarChar, 50)
                {
                    Value = entity.lastName
                };
                var PhoneNumberParam = new SqlParameter("@phoneNumber", SqlDbType.VarChar, 20)
                {
                    Value = entity.phoneNumber
                };
                var EmailParam = new SqlParameter("@email", SqlDbType.VarChar, 50)
                {
                    Value = entity.email
                };
                var NotesParam = new SqlParameter("@notes", SqlDbType.VarChar, 100)
                {
                    Value = entity.notes
                };
                var TotalPurchaseAmount = new SqlParameter("@totalPurchasesAmount", SqlDbType.Decimal)
                {
                    Value = entity.totalPurchaseAmount
                };
                var CustomerID = new SqlParameter("@customerID", SqlDbType.Int)
                {
                    Value = entity.customerID
                };
                command.Parameters.Add(FistNameParam);
                command.Parameters.Add(LastNameParam);
                command.Parameters.Add(PhoneNumberParam);
                command.Parameters.Add(EmailParam);
                command.Parameters.Add(NotesParam);
                command.Parameters.Add(TotalPurchaseAmount);
                command.Parameters.Add(CustomerID);
                command.ExecuteNonQuery();
            }
        }
        public void DeleteAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "DELETE FROM dbo.Customers WHERE customer_ID > 428", connection);
                command.ExecuteNonQuery();
            }
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT * FROM dbo.[Customers]", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            customerID = Convert.ToInt32(reader["customer_ID"]),
                            firstName = reader["first_name"].ToString(),
                            lastName = reader["last_name"].ToString(),
                            email = reader["email"].ToString(),
                            notes = reader["notes"].ToString(),
                            phoneNumber = reader["phone_number"].ToString(),
                            totalPurchaseAmount = Convert.ToDecimal(reader["total_purchases_amount"])
                        });
                    }
                }
            }
            return customers;
        }



        public int GetID()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT customer_ID FROM dbo.Customers", connection);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["customer_ID"]);
                }
                else
                    return 0;
            }
        }
        public List<int> GetAllId()
        {
            var allId = new List<int>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT DISTINCT address_ID FROM dbo.[Addresses]", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        allId.Add(Convert.ToInt32(reader["address_ID"]));
                    }
                }
            }
            return allId;
        }
    }
}
