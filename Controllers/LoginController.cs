using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoneyTransfer.Models;
using MoneyTransfer.ViewModels;

namespace MoneyTransfer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        public LoginController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVm Model)
        {
           
            if (!ModelState.IsValid)
            {
                return View(Model);
            }
            var user = await userManager.FindByEmailAsync(Model.email);
            if (user == null) 
            {
                ModelState.AddModelError(string.Empty, "Email or Password is Invalid");
                return View(Model);
            }
            if (!user!.EmailConfirmed) 
            {
                ModelState.AddModelError(string.Empty, "Please verify your email before logging in.");
                return View(Model);
            }
            var result = await signInManager.PasswordSignInAsync(user, Model.password, Model.rememberMe,false);
            if (!result.Succeeded) {
                ModelState.AddModelError(string.Empty, "Invalid email or Password");
                return View(Model);
            }
            TempData["Success"] = $"Login Successfull";
            return RedirectToAction("Index","Dashboard");
        }

    }
}
