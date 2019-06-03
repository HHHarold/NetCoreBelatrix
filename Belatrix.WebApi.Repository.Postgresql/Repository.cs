using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Threading.Tasks;

namespace Belatrix.WebApi.Repository.Postgresql
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BelatrixDbContext _belatrixDbContext;
        public Repository(BelatrixDbContext belatrixDbContext)
        {
            _belatrixDbContext = belatrixDbContext;
        }

        public async Task<int> Create(T entity)
        {
            await _belatrixDbContext.Set<T>().AddAsync(entity);
            return await _belatrixDbContext.SaveChangesAsync();
        }

        public async Task<bool> Delete(T entity)
        {
            _belatrixDbContext.Set<T>().Remove(entity);
            return await _belatrixDbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable> ReadAsync()
        {
            return await _belatrixDbContext.Set<T>().ToListAsync();
        }

        public async Task<bool> Update(T entity)
        {
            _belatrixDbContext.Set<T>().Update(entity);
            return await _belatrixDbContext.SaveChangesAsync() > 0;
        }
    }
}
