
using Domain.Common;

namespace Application.IRepositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> Get(int id,string createdById);
        Task<IEnumerable<T>> Get(string createdBy);

        Task<T> Add(T entity);

        Task<T> Update(T entity);

        Task Delete(int id, string createdById);
    }
}
