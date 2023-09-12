using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WireChat.Controllers
{
    public class SignUpController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        [BindProperty]
        [Required(ErrorMessage = "Enter valid first name!")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "First name can contain only upper and lower case letters!")]
        public string FirstName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Enter valid last name!")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Last name can contain only upper and lower case letters!")]
        public string LastName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Enter valid username!")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "User name can contain only upper and lower case letters!")]
        public string UserName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Enter valid email!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Enter valid password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Confirmed password is required!")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp()
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Index", "Chat");
            }

            return View("Index");
        }
    }
}
