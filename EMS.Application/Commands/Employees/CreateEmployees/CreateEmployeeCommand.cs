using EMS.Application.Common.Models;
using EMS.Entities.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Commands.Employees.CreateEmployees
{
    public class CreateEmployeeCommand : IRequest<ResponseDetail<Employee>>
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; }
        public int DepartmentId { get; set; }
    }
}
