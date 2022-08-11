using Dapper;
using EMS.Application.Interfaces;
using EMS.Entities.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Data.DAL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IConfiguration configuration;

        public DepartmentRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<IEnumerable<Department>> GetAll()
        {
            var sql = "GetDepartments";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Department>(sql);
                return result.ToList();
            }
        }

        public async Task<Department?> GetById(int id)
        {
            var sql = "GetDepartments";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<Department>(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> Remove(int id)
        {
            var sql = "DeleteDepartments";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id, UpdatedBy = "Anonymous" }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> Update(Department entity)
        {
            var sql = "CreateDepartment";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var parameters = new { entity.Id, entity.DepartmentName, entity.MakeBy, entity.UpdatedBy };
                var result = await connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
