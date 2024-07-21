
using Domain.Common;

namespace Application.IRepositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> Get(string id, string createdById);
        Task<IEnumerable<T>> Get(string createdBy);

        Task<T> Add(T entity);

        T Update(T entity);

        Task Delete(string id, string createdById);
    }
}
