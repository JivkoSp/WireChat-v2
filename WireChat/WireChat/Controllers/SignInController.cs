using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Controllers
{
    public class SignInController : Controller
    {
        private readonly SignInManager<UserReadModel> _signInManager;

        [BindProperty]
        [Required(ErrorMessage = "Incorrect username or password.")]
        public string UserName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Incorrect username or password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        public bool RememberMe { get; set; }


        public SignInController(SignInManager<UserReadModel> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(UserName, Password, RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Main");
                }

                // TODO: Add logic for two factor authentication 
            }

            return View("Index");
        }
    }
}
