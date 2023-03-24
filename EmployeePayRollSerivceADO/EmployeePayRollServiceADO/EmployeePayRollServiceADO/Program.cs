using static System.Formats.Asn1.AsnWriter;

namespace EmployeePayRollServiceADO
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("welcome to employee pay roles services");
            EmployeeReposities employeeReposities = new EmployeeReposities();
            List<PayRolesData> payRoles = new List<PayRolesData>();
            PayRolesData payRolesData = new PayRolesData();
            StoreProcedFetchPayRoll store = new StoreProcedFetchPayRoll();

            //For ER 
            List<PayRolesForER> payRoleERs = new List<PayRolesForER>();
            PayRolesForER payER = new PayRolesForER();

            try
            {
                Console.WriteLine("Hint 1.check connection 2.display sql data 3.Update Data 4.Retrive Data by name 5.Aggregate Function 6.Add data" +
                    "\n CRUD OPERATION \n 7.fetch data show ,8.fetch data add,9.fetch data update,10.fetch data delete");
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
                    case 6:
                        string queryAdd = @"INSERT INTO employeePayRoleTable(Name, Salary,Gender)VALUES(@Name,@Salary,@Gender)";
                        payRolesData.Name ="Rani";
                        payRolesData.Salary =0000000;
                        payRolesData.Gender = "Female";
                        employeeReposities.AddRecordEmployee(payRolesData, queryAdd);
                        break;
                    case 7:
                        store.Fetch_GetAllEmployee(payRoles);
                        break;
                    case 8:
                        payRolesData.Name ="Bharti";
                        payRolesData.Salary =21454646;
                        payRolesData.Gender = "Female";
                        store.Fetch_AddRecordEmployee(payRolesData);
                        break;
                    case 9:
                        payRolesData.Id = 7;
                        payRolesData.Name ="Raghvi";
                        payRolesData.Salary =21454646;
                        payRolesData.Gender = "Female";
                        store.Fetch_UpdateRecordEmployee(payRolesData);
                        break;
                    case 10:
                        payRolesData.Id = 9;
                        store.Fetch_DeleteRecordEmployee(payRolesData);
                        break;
                    case 11:
                        string queryDelect = @"DELETE FROM employeePayRoleTable WHERE Name = @Name";
                        payRolesData.Name="Terisa";
                        employeeReposities.DeleteRecordEmployee(payRolesData, queryDelect);
                        break;
                    case 12:
                        string queryER = @"SELECT * FROM EmployeeDetail_ado AS C inner join Salary_ado AS D ON C.EmpId=D.EmpId";
                        employeeReposities.ER_DIAGRAMGetAllEmployee(payRoleERs, queryER);
                        break;
                    case 13:
                        string queryaddEr = @"INSERT INTO employeePayRoleTable(Name, Salary,Gender)VALUES(@Name,@Salary,@Gender) ";//correct
                        payER.EmpName ="Terisa";
                        payER.Gender = "Female";
                        payER.BasicPay=14243535;
                        payER.Deduction =22353;
                        payER.Tax=353535;

                        employeeReposities.ER_AddRecordEmployee(payER, queryaddEr);
                        employeeReposities.ER_AddRecordEmployee(payER, queryaddEr);
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
