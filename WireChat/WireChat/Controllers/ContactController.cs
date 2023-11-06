using Microsoft.AspNetCore.Mvc;

namespace WireChat.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult SearchContact()
        {
            return View();
        }
    }
}
