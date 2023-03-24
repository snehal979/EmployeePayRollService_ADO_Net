﻿using System;
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
        /// <summary>
        /// Uc2 Get All Retrive
        /// Uc 5Retrive all data In The DataBase
        /// </summary>
        /// <param name="payRoles"></param>
        /// <exception cref="Exception"></exception>
        public void GetAllEmployee(List<PayRolesData> payRoles, string query)
        {
            try
            {
                using (this.sqlconnection)
                {
                    this.sqlconnection.Open();
                    SqlCommand command = new SqlCommand(query, this.sqlconnection);
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
                            //Add Data in list
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
        /// UC3 Update data 
        /// </summary>
        /// <param name="payRoll"></param>
        /// <exception cref="Exception"></exception>
        public string UpdateRecordEmployee(PayRolesData payRoll, string query)
        {
            try
            {
                using (this.sqlconnection)
                {
                    SqlCommand command = new SqlCommand(query, this.sqlconnection);

                    command.Parameters.AddWithValue("@Name", payRoll.Name);
                    command.Parameters.AddWithValue("@Salary", payRoll.Salary);

                    this.sqlconnection.Open();
                    int a = command.ExecuteNonQuery();
                    if (a>0)
                    {
                        Console.WriteLine("Update data in the employeePayRoleTable serivces");
                        return "Update";
                    }
                    else
                    {
                        Console.WriteLine("Not Update data in the employeePayRoleTable serivces");
                        return "NotUpdate";
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
