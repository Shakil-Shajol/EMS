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
    public class EmployeeListQuery : IRequest<ResponseDetail<List<Employee>>>
    {
    }
}
