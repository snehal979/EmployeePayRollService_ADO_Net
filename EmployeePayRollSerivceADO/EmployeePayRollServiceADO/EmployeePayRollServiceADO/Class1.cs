using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollServiceADO
{
    public class EmployeeReposities
    {
        /// <summary>
        /// UC1 check connection  
        /// </summary>
        public static string connectionString = "Data Source =(localdb)\\MSSQLLocalDB;Initial Catalog =EmployeePayRoleADO";
        SqlConnection sqlconnection = new SqlConnection(connectionString);
        public void GetConnection()
        {
            try
            {
                this.sqlconnection.Open();
                if (this.sqlconnection.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connection Succesfully");
                }
                else
                {
                    Console.WriteLine("Connection not Succesfully");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }
    }
}
