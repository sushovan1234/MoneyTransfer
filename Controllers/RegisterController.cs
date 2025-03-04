using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoneyTransfer.Models;
using MoneyTransfer.Services.Interface;
using MoneyTransfer.ViewModels;

namespace MoneyTransfer.Controllers
{
    public class RegisterController : Controller
    {
       
        private readonly UserManager<User> userManager;
        private readonly IEmailSenderService emailSenderService;
        public RegisterController(UserManager<User> userManager,IEmailSenderService emailSenderService)
        {
            this.userManager = userManager;
            this.emailSenderService = emailSenderService;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm Model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = Model.firstName,
                    firstName = Model.firstName,
                    lastName = Model.lastName,
                    Email = Model.email,
                    formattedAddress = $"{Model.street},{Model.city},{Model.State},{Model.zipCode},{Model.country}"
                };
                var result = await userManager.CreateAsync(user, Model.password);
                if (result.Succeeded)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("verifyEmail", "Register", new { Token = token,Email = Model.email }, Request.Scheme);
                    string Message = $"Pls confirm your email by clicking <a href='{confirmationLink}'>here</a>";
                    bool sendVerificationlink = await emailSenderService.SendEmailAsync(Model.email, "Email Verification", Message); 
                    TempData["Info"] = $"email verification link has been sent to {Model.email}";
                    return RedirectToAction("Login", "Login");
                }
                
            }

            return View(Model);
        }

        public async Task<IActionResult> verifyEmail(string Token,string Email)
        {
            if (String.IsNullOrEmpty(Token) || String.IsNullOrEmpty(Email))
                return BadRequest("Invalid Email Confirmation Request");
            var user = await userManager.FindByEmailAsync(Email);
            if (user == null)
                return NotFound("User Not Found");

            var result = await userManager.ConfirmEmailAsync(user, Token);
            if (result.Succeeded)
                return RedirectToAction("Login","Login");
            return BadRequest("Email Verification Failed");
        }

    }
}
