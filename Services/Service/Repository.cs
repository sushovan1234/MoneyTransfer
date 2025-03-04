using Microsoft.EntityFrameworkCore;
using MoneyTransfer.Services.Interface;
using System.Linq.Expressions;
using System.Linq;

namespace MoneyTransfer.Services.Service
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MoneyTransfer.Data_Access.AppContext appContext;
        internal DbSet<T> Dbset;

        public Repository(MoneyTransfer.Data_Access.AppContext appContext)
        {
            this.appContext = appContext;
            this.Dbset = appContext.Set<T>();
        }
        public async Task Add(T entity)
        {
            try
            {
                await Dbset.AddAsync(entity);
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);
            }
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = Dbset;

            }
            else
            {
                query = Dbset.AsNoTracking();
            }

            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = Dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.ToListAsync();
        }

        public void Remove(T entity)
        {
            try
            {
                Dbset.Remove(entity);

            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);
            }
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            try
            {
                Dbset.RemoveRange(entity);

            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await appContext.SaveChangesAsync();

            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);

            }
        }
    }
}
