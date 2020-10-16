using College_Database.Contracts;
using College_Database.Core.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace College_Database.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly RepositoryContext RepositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> exception)
        {
            return RepositoryContext.Set<T>().Where(exception).AsNoTracking();
        }

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }

        public async Task<T> FindByIdAsync(int id)
        {
            var item = await RepositoryContext.Set<T>().FindAsync(id);
            return item;
        }

        public Task SaveChangesAsync()
        =>    RepositoryContext.SaveChangesAsync();
        
    }
}
