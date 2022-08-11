using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; } = DateTime.Parse("1/1/1753");
        public int DepartmentId { get; set; }
    }
}
