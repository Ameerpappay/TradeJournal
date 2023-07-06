
using Domain.Common;

namespace Application.IRepositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get();

        Task<T> Add(T entity);

        Task<T> Update(T entity);

        Task Delete(int id);
    }
}
