using Microsoft.AspNetCore.Mvc;

namespace WireChat.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
