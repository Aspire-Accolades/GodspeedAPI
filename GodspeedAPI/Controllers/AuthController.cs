using Microsoft.AspNetCore.Mvc;

namespace GodspeedAPI.Controllers
{
  public class AuthController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
