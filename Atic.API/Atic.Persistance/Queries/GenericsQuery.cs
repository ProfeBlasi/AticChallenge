using Atic.Domain.Interface.Queries;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Atic.Persistance.Queries
{
    public class GenericsQuery : DelegatedDbConnection, IGenericsQuery
    {
        public GenericsQuery(IDbConnection connection) : base(connection)
        {
        }

        public async Task<bool> Exist(string table, string column, string[] values = null)
        {
            var sql = $@"
                    SELECT IF( EXISTS(
                        SELECT *
                        FROM {table}
                        WHERE {column} in @values
                    ), TRUE ,FALSE)";
            return await _connection.QueryFirstOrDefaultAsync<bool>(sql, new { values });
        }

        public async Task<List<T>> GetAll<T>(string table) where T : class
        {
            var sql = $@"
                    SELECT *
                    FROM {table};
                    ";
            return (await _connection.QueryAsync<T>(sql, new { table })).AsList();
        }

        public async Task<T> GetById<T>(string table, string column, string id) where T : class
        {
            var sql = $@"
                    SELECT *
                    FROM {table}
                    WHERE {column} = @id
                    ";
            return await _connection.QueryFirstOrDefaultAsync<T>(sql, new { table, column, id });
        }
    }
}
