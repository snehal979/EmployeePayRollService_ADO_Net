namespace EmployeePayRollServiceADO
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("welcome to employee pay roles services");
            EmployeeReposities employeeReposities = new EmployeeReposities();
            employeeReposities.GetConnection();
            Console.ReadLine();
        }
    }
}
