using System.Threading.Tasks;
using Shop_Back.Models;
using Shop_Back.Repository;

namespace Shop_Back.Properties
{
  public class Global
  {
    private readonly IAdminRepository _repo;
    public Global(IAdminRepository repo)
    {
      _repo = repo;
      UserId = _repo.GetUserByName("Omar");
    }
    public static User UserId { get; set; }

  }
}