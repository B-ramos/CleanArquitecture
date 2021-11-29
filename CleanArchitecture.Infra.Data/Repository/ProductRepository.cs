using CleanArchitecture.Infra.Data.Context;
using CleanArchitecture.Domain.IRepository;
using CleanArchitecture.Domain.Model;

namespace CleanArchitecture.Infra.Data.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(CleanArchictetureContext context) : base(context)
        {
        }
    }
}
