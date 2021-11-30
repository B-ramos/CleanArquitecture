using CleanArchitecture.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.IRepository
{
    // Repositorio base, where tipo ModelBase porque precisamos do id e do enum active para fazer os métodos
    // Tipo o exemplo do Factory
    public interface IBaseRepository<T> where T : ModelBase 
    {
        // métodos basicos
        Task<List<T>> ListAllActive();
        Task<T> FindById(long id);
        Task<T> Add(T model);
        Task<T> Update(T model);
        Task Delete(T model);
    }
}
