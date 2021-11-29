using CleanArchitecture.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.IRepository
{
    public interface IBaseRepository<T> where T : ModelBase 
    {
        Task<List<T>> ListAllActive();
        Task<T> FindById(long id);
        Task<T> Add(T model);
        Task<T> Update(T model);
        Task Delete(T model);
    }
}
