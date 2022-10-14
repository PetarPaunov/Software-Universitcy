using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Core.Data.Models;
using TaskBoardApp.Models;

namespace TaskBoardApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(
            UserManager<ApplicationUser> _userManager, 
            SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public async Task<IActionResult> Register()
        {
            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                UserName = model.UserName,
                LastName = model.LastName
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(String.Empty, error.Description);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            var model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.Username);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    if (model.ReturnUrl != null)
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid Login!");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
