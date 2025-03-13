using DBUtility;
using HRManagementSystemDDD.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystemDDD.Infrastructure.Repositories.Leaves
{
    public interface ILeaveAggregateRepository
    {
        public Task<int> DeleteAsync(int Id);
    }
    public class LeaveAggregateRepository : IRepository<Domain.AggregatesModel.LeaveAggregate.Leave>, ILeaveAggregateRepository
    {
        private readonly IDataBaseUtility dataBaseUtility;

        public LeaveAggregateRepository(IDataBaseUtility dataBaseUtility)
        {
            this.dataBaseUtility = dataBaseUtility;
        }

        public async Task<int> DeleteAsync(int Id)
        {
            string sql = @"
DELETE FROM Leave WHERE Id = @Id
";
            List<SqlParameter> sqlParameter = new()
            {
                new SqlParameter("Id", System.Data.SqlDbType.Int) { Value = Id }
            };

            return await dataBaseUtility.DeleteAsync(sql, sqlParameter);
        }
    }
}
