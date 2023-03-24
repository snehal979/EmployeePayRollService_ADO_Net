﻿namespace EmployeePayRollServiceADO
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("welcome to employee pay roles services");
            EmployeeReposities employeeReposities = new EmployeeReposities();
            List<PayRolesData> payRoles = new List<PayRolesData>();
            PayRolesData payRolesData = new PayRolesData();
            try
            {
                Console.WriteLine("Hint 1.check connection 2.display sql data 3.Update Data 4.Retrive Data by name 5.Aggregate Function");
                int num = Convert.ToInt32(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        employeeReposities.GetConnection();
                        break;
                    case 2:
                        string query = @"Select * from employeePayRoleTable";
                        employeeReposities.GetAllEmployee(payRoles, query);
                        break;
                    case 3:
                        payRolesData.Name ="Terisa";
                        payRolesData.Salary = 300000;
                        string Updatequery = @"UPDATE employeePayRoleTable SET Salary =@Salary WHERE Name=@Name";
                        employeeReposities.UpdateRecordEmployee(payRolesData, Updatequery);
                        break;
                    case 4:
                        //Uc4 Retrive data from Name
                        string retrivequery = @"SELECT * FROM employeePayRoleTable where Name = 'Snehal'";
                        employeeReposities.GetAllEmployee(payRoles, retrivequery);
                        break;
                    case 5:
                        Console.WriteLine("1.Max Salary 2.Min Salary 3.Sum Of Salary 4.Avg 5.Count");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                string queryMax = @"Select Max(Salary) from employeePayRoleTable where Gender ='Female' group by Gender";
                                long bMax = employeeReposities.AggGetAllEmployee(payRoles, queryMax);
                                Console.WriteLine("Max salary in data " +bMax);
                                break;
                            case 2:
                                string queryMin = @"Select Min(Salary) from employeePayRoleTable where Gender = 'Female' group by Gender";
                                long bMin = employeeReposities.AggGetAllEmployee(payRoles, queryMin);
                                Console.WriteLine("Min salary in data "+bMin);
                                break;
                            case 3:
                                string querySum = @"Select Sum(Salary) from employeePayRoleTable where Gender = 'Female' group by Gender";
                                long bSum = employeeReposities.AggGetAllEmployee(payRoles, querySum);
                                Console.WriteLine("sum salary in data "+bSum);
                                break;
                            case 4:
                                string queryAvg = @"Select Avg(Salary) from employeePayRoleTable where Gender ='Female' group by Gender";
                                long bAvg = employeeReposities.AggGetAllEmployee(payRoles, queryAvg);
                                Console.WriteLine("Avg salary in data "+bAvg);
                                break;

                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
