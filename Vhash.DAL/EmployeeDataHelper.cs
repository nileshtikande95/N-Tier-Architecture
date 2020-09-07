using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vhash.Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Vhash.DAL
{
    public class EmployeeDataHelper:IEmployeeDataHelper
    {
        private string _connectionString;

        public EmployeeDataHelper()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        }
       public List<Employee> GetEmployees()
        {
            List<Employee> employees = null;

            employees = new List<Employee>();
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("usp_CRUD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Display", 1);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Employee emp = new Employee();
                emp.Id = Convert.ToInt32(reader["Id"]);
                emp.Name = reader["Name"].ToString();
                emp.Email = reader["Email"].ToString();
                emp.Mobile = reader["Mobile"].ToString();
                emp.Date = reader["Date"].ToString();
                emp.Gender = reader["Gender"].ToString();
                emp.Department = reader["Department"].ToString();
                emp.Salary = Convert.ToInt32(reader["Salary"]);
                employees.Add(emp);
            }
            return employees;


        }
    }
}
