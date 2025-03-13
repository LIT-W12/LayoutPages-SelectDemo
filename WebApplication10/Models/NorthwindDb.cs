
using System.Data.SqlClient;

namespace WebApplication10.Models
{

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Region { get; set; }
        public DateTime? BirthDate { get; set; }
    }

    public class NorthwindDb
    {
        private string _connectionString;

        public NorthwindDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        private string Foo()
        {
            return "";
        }

        public List<Product> GetProducts()
        {

            var connection = new SqlConnection(_connectionString);
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Products";
            List<Product> products = new();
            connection.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                products.Add(new()
                {
                    Id = (int)reader["ProductId"],
                    Name = (string)reader["ProductName"],
                    UnitPrice = (decimal)reader["UnitPrice"]
                });
            }

            return products;

        }


        public List<Employee> GetEmployees()
        {

            //int? x = null;
            //if(x.HasValue) //x != null
            //{
            //    int u = x.Value;
            //}

            var connection = new SqlConnection(_connectionString);
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Employees";
            List<Employee> employees = new List<Employee>();
            connection.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var employee = new Employee()
                {
                    Id = (int)reader["EmployeeId"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Region = reader.GetOrNull<string>("Region"),
                    BirthDate = reader.GetOrNull<DateTime?>("BirthDate")
                };

                employees.Add(employee);
            }

            return employees;
        }

    }
}
