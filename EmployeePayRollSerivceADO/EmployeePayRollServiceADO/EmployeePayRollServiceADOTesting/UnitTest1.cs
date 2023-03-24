using EmployeePayRollServiceADO;
namespace EmployeePayRollServiceADOTesting
{
    [TestClass]
    public class UnitTest1
    {
        EmployeeReposities employeeReposities = new EmployeeReposities();
        PayRolesData payRoll = new PayRolesData();
        /// <summary>
        /// Uc3 Update Code for Terisa Salary Set by Name
        /// </summary>
        [TestMethod]
        public void UpdateData_ReturnUpdate_Message()
        {
            payRoll.Name ="Terisa";
            payRoll.Salary = 300000;
            string Updatequery = @"UPDATE employeePayRoleTable SET Salary =@Salary WHERE Name=@Name";
            string actual = employeeReposities.UpdateRecordEmployee(payRoll, Updatequery);

            Assert.AreEqual(actual, "Update");
        }
    }
}