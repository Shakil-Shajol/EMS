using EMS.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Data.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IDepartmentRepository departmentRepository;

        public UnitOfWork(
            IConfiguration configuration, 
            IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository
        )
        {
            _configuration = configuration;
            this.employeeRepository = employeeRepository;
            this.departmentRepository = departmentRepository;
        }
        public IEmployeeRepository EmployeeRepository 
        {
            get { return employeeRepository; }
        }

        public IDepartmentRepository DepartmentRepository
        {
            get { return departmentRepository; }
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
