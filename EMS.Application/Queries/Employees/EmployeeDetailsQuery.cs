using EMS.Application.Common.Models;
using EMS.Entities.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Queries.Employees
{
    public class EmployeeDetailsQuery : IRequest<ResponseDetail<Employee>>
    {
        public int Id { get; set; }
    }
}
