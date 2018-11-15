using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop_Back.Models;
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

    [HttpPost("cart/{userId}")]
    public async Task<IActionResult> PostCartItems(int userId, [FromBody] CartItem cartItem)
    {
      var cart = await _repo.GetCartByUserId(userId);
      if (cart == null)
      {
        return BadRequest("Cart does not exist for the current user!");
      }

      var existingCartItems = cart.CartItems;
      CartItem cartItemToAdd = cartItem;
      cartItemToAdd.CartId = cart.Id;
      var qunatity = 1;
      foreach (CartItem item in existingCartItems)
      {
        if(item.ProductId == cartItem.ProductId)
        {
          cartItemToAdd = item;
          qunatity = qunatity + item.Quantity;
        }
      }
      cartItemToAdd.Quantity = qunatity;
      if (cartItemToAdd.Quantity > 1)
      {
        _repo.UpdateCartItem(cartItemToAdd);
      }
      else 
      {
        _repo.Add(cartItemToAdd);
      }

      var result = await _repo.SaveAll();

      return Ok(result);
    }

    [HttpGet("cart/{userId}")]
    public async Task<IActionResult> GetCart(int userId)
    {
      var cart = await _repo.GetCartByUserId(userId);
      return Ok(cart);
    }

    [HttpDelete("cartItem/{cartItemId}")]
    public async Task<IActionResult> DeleteCartItem(int cartItemId)
    {
      var cartItem = await _repo.GetCartItem(cartItemId);
      if(cartItem == null)
      {
        return NotFound();
      }
      _repo.Delete(cartItem);
      var result = await _repo.SaveAll();

      return Ok(result);
    }
  }
}