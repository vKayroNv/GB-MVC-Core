using AbstractCompany.Identity.Models;
using AbstractCompany.MVC.ViewModels.Account;
using AbstractCompany.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AbstractCompany.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly EmailService _emailService;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<AccountController> logger,
            EmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailService = emailService;
        }

        public IActionResult Register() => View(new RegisterViewModel());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel Model)
        {
            if (!ModelState.IsValid)
            {
                return View(Model);
            }

            var user = new User
            {
                UserName = Model.Username,
                Email = Model.Email
            };

            var result = await _userManager.CreateAsync(user, Model.Password);
            if (result.Succeeded)
            {
                _logger.LogInformation($"Пользователь {user} успешно создан");

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action(
                    "ConfirmEmail",
                    "Account",
                    new { userId = user.Id, code = code },
                    protocol: HttpContext.Request.Scheme);

                await _emailService.SendConfirmationEmailAsync(Model.Email, callbackUrl);

                return RedirectToAction("EmailConfirmation", "Account");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(Model);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction("AccessDenied", "Account");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return RedirectToAction("AccessDenied", "Account");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return View();
            }

            return RedirectToAction("AccessDenied", "Account");
        }

        public IActionResult Login(string? ReturnUrl = null) => View(new LoginViewModel { ReturnUrl = ReturnUrl });

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel Model)
        {
            if (!ModelState.IsValid)
            {
                return View(Model);
            }

            var user = await _userManager.FindByNameAsync(Model.Username);
            if (user != null)
            {
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(string.Empty, "Вы не подтвердили свой email");
                    return View(Model);
                }
            }

            var result = await _signInManager.PasswordSignInAsync(Model.Username, Model.Password, Model.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Неправильный логин и (или) пароль");
            }

            return View(Model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied() => View();

        public IActionResult EmailConfirmation() => View();
    }
}
