using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atic.Domain.Interface.Command
{
    public interface IGenericsCommand
    {
        Task SaveChangeAsync();
        void Add<T>(T entity) where T : class;
        T AddEntity<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<T> Find<T>(object id) where T : class;
        IQueryable<T> Query<T>() where T : class;
    }
}