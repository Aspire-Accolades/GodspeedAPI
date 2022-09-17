using GodspeedAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GodspeedAPI.Controllers.Base
{
  public class BaseController : Controller
  {
    public BaseController()
    {

    }
    public IActionResult Index()
    {
      return View();
    }
  }
}
