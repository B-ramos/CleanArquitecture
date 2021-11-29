using CleanArchitecture.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.IService
{
    public interface IProductService
    {
        Task<List<Product>> ListAllActive();
        Task<Product> FindById(long id);
        Task<Product> Add(Product product);
        Task<Product> Update(long id, Product product);
        Task Delete(long id);
    }
}
