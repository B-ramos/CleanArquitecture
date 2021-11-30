using CleanArchitecture.Domain.IService;
using CleanArchitecture.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // variável somente leitura, iniciar com _variável é so um padrão para tipo privado        
        private readonly IProductService _productService;

        // no construtor recebe por parâmetro o IService, fazendo injeção de dependencia, elimina o acoplamento não precisando instanciar com new
        // essa configuração está na class startup(caso resolvemos fazer no net 6 ficará na class program)
        public ProductController(IProductService productService)
        {
            // através da variável _productService, chamamos a camada de service(negócio) depois do ponto especifica o método a ser chamado.
            _productService = productService; 
        }

        [HttpGet]// representa o método que será utilizado n endpoint
        public async Task<IActionResult> Get() // IActionResult representa vários códigos de status HTTP(OK, Notfound, noContent ....)
        {
            var products = await _productService.ListAllActive();
            return Ok(products); 
        }

        [HttpGet("{id}")] // "{id}" representa que é preciso adicionar um id na rota
        public async Task<IActionResult> GetById(long id)
        {
            var product = await _productService.FindById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            var newProduct = await _productService.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Product product)
        {
            var updateProduct = await _productService.Update(id, product);
            return Ok(updateProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _productService.Delete(id);
            return NoContent();
        }
    }
}
