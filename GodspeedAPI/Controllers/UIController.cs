using Microsoft.AspNetCore.Mvc;

namespace GodspeedAPI.Controllers
{
    public class UIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
