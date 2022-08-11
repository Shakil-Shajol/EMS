using Dapper;
using EMS.Application.Interfaces;
using EMS.Entities.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EMS.Data.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region Private Fields

        private readonly IConfiguration configuration;

        #endregion Private Fields

        #region Public Constructors

        public EmployeeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion Public Constructors

        #region Public Methods

        public async Task<IEnumerable<EmployeeReadDto>> GetAll<EmployeeReadDto>()
        {
            var sql = "GetEmployees";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<EmployeeReadDto>(sql);
                return result.ToList();
            }
        }

        public async Task<Employee?> GetById<Employee>(int id)
        {
            var sql = "GetEmployees";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<Employee>(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> Remove(int id)
        {
            var sql = "DeleteEmployees";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id, UpdatedBy = "Anonymous" }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> Update(Employee entity)
        {
            var sql = "CreateEmployee";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var parameters = new { entity.Id, entity.EmployeeName, entity.JoinDate, entity.DepartmentId, entity.MakeBy, entity.UpdatedBy };
                var result = await connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        #endregion Public Methods
    }
}
