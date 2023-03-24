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
            try
            {
                Console.WriteLine("Hint 1.check connection 2.display sql data 3.Update Data 4.Retrive Data by name");
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
