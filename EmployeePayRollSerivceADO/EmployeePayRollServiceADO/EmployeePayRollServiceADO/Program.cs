namespace EmployeePayRollServiceADO
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("welcome to employee pay roles services");
            EmployeeReposities employeeReposities = new EmployeeReposities();
            List<PayRolesData> payRoles = new List<PayRolesData>();
            try
            {
                Console.WriteLine("Hint 1.check connection 2.display sql data");
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
