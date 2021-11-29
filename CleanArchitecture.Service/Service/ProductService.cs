using CleanArchitecture.Domain.IRepository;
using CleanArchitecture.Domain.IService;
using CleanArchitecture.Domain.Model;
using CleanArchitecture.Service.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> ListAllActive()
        {
            return await _productRepository.ListAllActive();
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

            var productExists = await _productRepository.FindById(id);

            Verification.ArgumentIsNull(productExists, "Product not found!");

            productExists.Update(product);

            return await _productRepository.Update(productExists);

        }

        public async Task Delete(long id)
        {
            var productExists = await _productRepository.FindById(id);

            Verification.ArgumentIsNull(productExists, "Product not found!");

            await _productRepository.Delete(productExists);
        }
    }
}
