using CleanArchitecture.Domain.IRepository;
using CleanArchitecture.Domain.IService;
using CleanArchitecture.Domain.Model;
using CleanArchitecture.Service.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Service
{
    public class ProductService : IProductService // implementa a interface(contrato)
    {
        private readonly IProductRepository _productRepository;// _productRepository representa a camada de persistência

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> ListAllActive()
        {
            return await _productRepository.ListAllActive();// funciona igual no controller, só que neste caso se comunicando com a camada de repositorio(persistência)
        }

        public async Task<Product> FindById(long id)
        {
            return await _productRepository.FindById(id);
        }

        public async Task<Product> Add(Product product)
        {
            return await _productRepository.Add(product);
        }

        public async Task<Product> Update(long id, Product product)
        {

            var productExists = await _productRepository.FindById(id);// busca no banco um produto pelo id

            // Verfication é uma classe abstrata(Pasta Utils), lá eu coloco métodos que são comuns entre varios objetos para não ficar repetindo código
            Verification.ArgumentIsNull(productExists, "Product not found!");// (productExists, "Product not found!") paramêtros, aqui podria ser feito um enum representando o erro

            productExists.Update(product); // chama o método da classe produto, poderia ser feito aqui direto, fiz mais por exemplo, lá ele válida se esta ok

            return await _productRepository.Update(productExists);// chama camada repositótio, onde é feita a logica com o banco de dados

        }

        public async Task Delete(long id)
        {
            var productExists = await _productRepository.FindById(id);

            Verification.ArgumentIsNull(productExists, "Product not found!");

            await _productRepository.Delete(productExists);
        }
    }
}
