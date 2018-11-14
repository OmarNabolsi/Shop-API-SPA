using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop_Back.Models;
using Shop_Back.Repository;

namespace Shop_Back.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IAdminRepository _repo;
        public ProductsController(IAdminRepository repo)
        {
            _repo = repo;
        }

        // POST api/admin/products
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            _repo.Add(product);
            var result = await _repo.SaveAll();
            return Ok(result);
        }

        // GET api/admin/products/:id
        [Route("api/admin/user/products")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _repo.GetProduct(id);
            return Ok(product);
        }

        // GET api/admin/products/user/:id
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetProductByUserId(int id)
        {
            var products = await _repo.GetProducts(id);
            return Ok(products);
        }

        // PUT api/admin/products/:id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            var prod = await _repo.GetProduct(id);
            prod.Title = product.Title;
            prod.ImageUrl = product.ImageUrl;
            prod.Price = product.Price;
            prod.Description = product.Description;

            _repo.UpdateProduct(prod);
            var result = await _repo.SaveAll();
            return Ok(result);
        }

        // DELETE api/admin/products/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var prod = await _repo.GetProduct(id);
            _repo.Delete(prod);
            
            var result = await _repo.SaveAll();
            return Ok(result);
        }
    }
}