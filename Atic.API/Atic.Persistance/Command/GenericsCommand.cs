using Atic.Domain.Interface.Command;
using Atic.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atic.Persistance.Command
{
    public class GenericsCommand : IGenericsCommand
    {
        private readonly AticPruebaDeCandidatosContext _context;

        public GenericsCommand(AticPruebaDeCandidatosContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);

        }


        public T AddEntity<T>(T entity) where T : class
        {
            _context.Add(entity);
            return entity;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<T> Find<T>(object id) where T : class
        {
            return await _context.FindAsync<T>(id);
        }

        public virtual IQueryable<T> Query<T>() where T : class
        {
            var query = _context.Set<T>().AsQueryable();

            var navigations = _context.Model.FindEntityType(typeof(T))
                .GetDerivedTypesInclusive()
                .SelectMany(type => type.GetNavigations())
                .Distinct();

            foreach (var property in navigations)
                query = query.Include(property.Name);

            return query;
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Attach<T>(entity);
            _context.Update(entity);
        }
    }
}

