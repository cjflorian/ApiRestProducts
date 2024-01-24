using Microsoft.AspNetCore.Mvc;
using ProductMicroservicesProject.Models;
using ProductMicroservicesProject.Repository;
using System.Transactions;

namespace ProductMicroservicesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController (IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult Get() { 
            var products = _productRepository.GetProducts();
            return new OkObjectResult(products);
        }

        [HttpGet("{id}", Name ="Get")]
        public IActionResult Get(int id)
        {
            var products = _productRepository.GetProductById(id);
            return new OkObjectResult(products);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            using(var scope = new TransactionScope())
            {
                _productRepository.InsertProduct(product);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id= product.Id }, product);
            }
        }


        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
           if(product != null)
            {
                using (var scope = new TransactionScope())
                {
                    _productRepository.UpdateProduct(product);
                    scope.Complete();
                    return new OkObjectResult(product);
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id);
            return new OkResult();
        }
    }
}
