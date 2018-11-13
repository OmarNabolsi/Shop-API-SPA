using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop_Back.Models;
using Shop_Back.Repository;

namespace Shop_Back.Controllers
{
  [Route("api/admin/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly IAdminRepository _repo;
    public UsersController(IAdminRepository repo)
    {
      _repo = repo;
    }

    // GET api/admin/users
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _repo.GetUsers();
        return Ok(users);
    }
  }
}