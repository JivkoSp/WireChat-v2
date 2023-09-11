using Microsoft.AspNetCore.Mvc;

namespace WireChat.Controllers
{
    public class SignInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
