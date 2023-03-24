using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollServiceADO
{
    /// <summary>
    /// Model class with properties
    /// </summary>
    public class PayRolesData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Salary { get; set; }
        public string Gender { get; set; }
    }
}
