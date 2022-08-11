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

        public UnitOfWork(
            IConfiguration configuration, 
            IEmployeeRepository employeeRepository
        )
        {
            _configuration = configuration;
            this.employeeRepository = employeeRepository;
        }
        public IEmployeeRepository EmployeeRepository 
        {
            get { return employeeRepository; }
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
