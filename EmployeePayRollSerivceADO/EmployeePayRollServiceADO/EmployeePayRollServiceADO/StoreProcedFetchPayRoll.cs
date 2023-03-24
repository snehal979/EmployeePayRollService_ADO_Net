using EmployeePayRollServiceADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollServiceADO
{
    /// <summary>
    /// QUERY FOR THE STORE PROCEDURE //Uc5 CRUD OPERATION
    /// </summary>
    public class StoreProcedFetchPayRoll
    {
        /// <summary>
        /// All Retrive
        /// </summary>
        public static string connectionString = "Data Source =(localdb)\\MSSQLLocalDB;Initial Catalog =EmployeePayRoleADO";
        SqlConnection sqlconnection = new SqlConnection(connectionString);
        public void Fetch_GetAllEmployee(List<PayRolesData> payRoles)
        {
            try
            {

                using (this.sqlconnection)
                {
                    this.sqlconnection.Open();
                    string query = @"fetchGetEmployees";
                    SqlCommand command = new SqlCommand(query, this.sqlconnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            PayRolesData service = new PayRolesData();
                            service.Id =dr.GetInt32(0);
                            service.Name =dr.GetString(1);
                            service.Salary =dr.GetInt64(2);
                            service.Gender =dr.GetString(3);

                            payRoles.Add(service);
                        }
                        foreach (var data in payRoles)
                        {
                            Console.WriteLine(data.Id+" "+data.Name+" "+data.Salary+" "+data.Gender);
                        }
                    }
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

        /// <summary>
        /// Add insert
        /// </summary>
        /// <param name="payRoll"></param>
        /// <exception cref="Exception"></exception>
        public void Fetch_AddRecordEmployee(PayRolesData payRoll)
        {
            try
            {
                using (this.sqlconnection)
                {
                    string query = @"spAddNewEmpPayRoll";
                    SqlCommand command = new SqlCommand(query, this.sqlconnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", payRoll.Name);
                    command.Parameters.AddWithValue("@Salary", payRoll.Salary);
                    command.Parameters.AddWithValue("@Gender", payRoll.Gender);

                    this.sqlconnection.Open();
                    int a = command.ExecuteNonQuery();
                    if (a>0)
                    {
                        Console.WriteLine("Data Add in the employeePayRoleTable serivces");
                    }
                    else
                    {
                        Console.WriteLine("Not Data Add in the employeePayRoleTable serivces");
                    }

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
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="payRoll"></param>
        /// <exception cref="Exception"></exception>
        public void Fetch_UpdateRecordEmployee(PayRolesData payRoll)
        {
            try
            {
                using (this.sqlconnection)
                {

                    string query = @"spUpdateEmpDetails";
                    SqlCommand command = new SqlCommand(query, this.sqlconnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", payRoll.Id);
                    command.Parameters.AddWithValue("@Name", payRoll.Name);
                    command.Parameters.AddWithValue("@Salary", payRoll.Salary);
                    command.Parameters.AddWithValue("@Gender", payRoll.Gender);


                    this.sqlconnection.Open();
                    int a = command.ExecuteNonQuery();
                    if (a>0)
                    {
                        Console.WriteLine("Update data in the employeePayRoleTable serivces");
                    }
                    else
                    {
                        Console.WriteLine("Not Update data in the employeePayRoleTable serivces");
                    }

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
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="payRoll"></param>
        /// <exception cref="Exception"></exception>
        public void Fetch_DeleteRecordEmployee(PayRolesData payRoll)
        {
            try
            {
                using (this.sqlconnection)
                {

                    string query = @"spDeleteEmpByIdEmployee";
                    SqlCommand command = new SqlCommand(query, this.sqlconnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // command.Parameters.AddWithValue("@Name", payRoll.Name);
                    command.Parameters.AddWithValue("@Id", payRoll.Id);

                    this.sqlconnection.Open();
                    int a = command.ExecuteNonQuery();
                    if (a > 0)
                    {
                        Console.WriteLine("Data Delete in the employeePayRoleTable serivces");
                    }
                    else
                    {
                        Console.WriteLine("Not Data Delete in the employeePayRoleTable serivces");
                    }

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

