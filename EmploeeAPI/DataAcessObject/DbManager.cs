using EmploeeAPI.Models;
using MySql.Data.MySqlClient;
using StockMarket.DataAccessLayer;

namespace EmployeeMarket.DataAccessLayer
{
    public class DbManager
    {
        public DbManager() { }
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> allEmployees = new List<Employee>();

            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                string query = "SELECT * FROM Employees";
                cmd.CommandText = query;

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = int.Parse(reader["Id"].ToString());
                    var name = reader["Name"].ToString();
                    var department = reader["Department"].ToString();
                    var salary = double.Parse(reader["Salary"].ToString());
                    var city = reader["City"].ToString();

                    Employee Employee = new Employee
                    {
                        Id = id,
                        Name = name,
                        Department = department,
                        Salary = salary,
                        City = city
                    };
                    allEmployees.Add(Employee);
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            finally
            {
                con.Close();
            }

            return allEmployees;
        }
        public static bool InsertOneEmployee(Employee Employee)
        {
            bool status = false;
            string query = $"INSERT INTO Employees (Name, Department, City, Salary) VALUES('{Employee.Name}', '{Employee.Department}', {Employee.City}, {Employee.Salary})";

            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            try
            {
                con.Open();
                MySqlCommand command = new MySqlCommand(query, con);
                command.ExecuteNonQuery();
                status = true;

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            finally
            {
                con.Close();
            }

            return status;

        }
        public static bool UpdateEmployeeById(Employee Employee)
        {
            bool status = false;
            string query = $"UPDATE Employees SET Name = '{Employee.Name}',Department = '{Employee.Department}', Salary ={Employee.Salary} WHERE Id = {Employee.Id}";
            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            try
            {
                con.Open();
                MySqlCommand command = new MySqlCommand(query, con);
                command.ExecuteNonQuery();
                status = true;

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            finally
            {
                con.Close();
            }

            return status;

        }
        public static Employee EmployeeById(int id)
        {
            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            string query = $"SELECT * FROM Employees Where EmployeeId ={id}";
            try
            {
                MySqlCommand command = new MySqlCommand(query, con);
                con.Open();

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Employee
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        Name = reader["Name"].ToString(),
                        Department = reader["Department"].ToString(),
                        Salary = double.Parse(reader["Salary"].ToString()),
                        City = reader["City"].ToString()

                };
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
            return null;
        }
        public static Employee DeleteEmployeeById(int id)
        {
            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            try
            {
                Employee Employee = EmployeeById(id);
                if (Employee == null)
                {
                    return null;
                }
                if (Employee.Id == id)
                {
                    string query = "DELETE FROM Employees WHERE Id =" + id;
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    return Employee;
                }


            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            finally
            {
                con.Close();
            }

            return null;
        }
    }
}