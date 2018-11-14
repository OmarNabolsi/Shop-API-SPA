using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop_Back.Repository;

namespace Shop_Back.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ShopController : ControllerBase
  {
    private readonly IShopRepository _repo;
    public ShopController(IShopRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("products")]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _repo.GetProducts();
        return Ok(products);
    }

    [HttpGet("product/{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
      var product = await _repo.GetProductById(id);
      return Ok(product);
    }
  }
}