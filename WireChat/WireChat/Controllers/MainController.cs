using Microsoft.AspNetCore.Mvc;

namespace WireChat.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
