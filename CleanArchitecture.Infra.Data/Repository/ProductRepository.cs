using CleanArchitecture.Infra.Data.Context;
using CleanArchitecture.Domain.IRepository;
using CleanArchitecture.Domain.Model;

namespace CleanArchitecture.Infra.Data.Repository
{

    // Repositorio próprio da classe Produto, como ele implementa a interface Base automaticamente ele já possui os métodos dadrão
    // Um exemplo se quiser ter outra entidade (Endereço) e só criar o repositorio endereço e passar BaseRepository<Endereço>
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(CleanArchictetureContext context) : base(context)
        {
            //Aqui pode ser gerados métodos próprios da classe, um exemplo seria fazer uma busca personalizada 
        }
    }
}
