using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using NLayer.Core.DTOs;
using Microsoft.AspNetCore.Identity;
using NLayer.Core.Entities;

namespace NLayer.MVCApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);

            if (user != null  && await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                await _signInManager.SignInAsync(user, loginDto.RememberMe);
                return RedirectToAction("Index", "Reports");
            }
            return RedirectToAction("AccessDenied");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

           return RedirectToAction("SignIn", "Account");
        }
    }
} 
