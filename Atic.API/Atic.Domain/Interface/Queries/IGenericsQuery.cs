using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atic.Domain.Interface.Queries
{
    public interface IGenericsQuery : IReadOnlyConnection
    {
        Task<T> GetById<T>(string table, string column, string id) where T : class;
        Task<List<T>> GetAll<T>(string table) where T : class;
        Task<bool> Exist(string table, string column, string[] values = null);
    }
}
