using System;
using System.Collections;
using System.Threading.Tasks;

namespace Belatrix.WebApi.Repository
{
    public interface IRepository<T>
    {
        Task<int> Create(T entity);
        Task<IEnumerable> ReadAsync();
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
