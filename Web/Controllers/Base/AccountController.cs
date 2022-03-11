using Web.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.IServices.Identity;
using Shared.Common;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Shared.Models.API;
using Services.Services;
using Shared.Models.Identity;
using Microsoft.AspNetCore.Authentication;

namespace Web.Controllers.Base
{
    /// <summary>
    /// Account manangement
    /// </summary>
    public class AccountController : Controller
    {
        private readonly IUserService _userManager;
        private readonly ISignInService _signInManager;

        /// <summary>
        /// Construct services
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        public AccountController(IUserService userManager, ISignInService signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region Login / Regiser / Log out


        /// <summary>
        /// Get Login user
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel()
            {
                ReturnUrl = returnUrl,
            };
            return View(model);
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            //TOdo
            // login functionality
            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if (user != null)
            {

                if (!user.EmailConfirmed)
                {
                    ModelState.AddModelError(string.Empty, "User Not exists");
                    //return RedirectToAction("Login", loginViewModel);
                }

                var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, ApplicationConstants.LockoutOnFailure);

                if (result.Succeeded)
                {


                    var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Name, result.User.UserName),
                            new Claim(ClaimTypes.Email, result.User.Email),
                            new Claim(ClaimTypes.NameIdentifier, result.User.Id.ToString())
                        };
                    var Defaultidentity = new ClaimsIdentity(claims, "Default Identity");
                    var claimPric = new ClaimsPrincipal(new[] { Defaultidentity });


                    await HttpContext.SignInAsync(claimPric);
                    //HttpContext.User = claimPric;

                    // Get the roles for the user
                    if (loginViewModel.ReturnUrl != null && !string.IsNullOrWhiteSpace(loginViewModel.ReturnUrl))
                    {
                        return Redirect(loginViewModel.ReturnUrl);
                    }

                    if (await _userManager.IsInRoleAsync(user.Id, "Guest"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    if (await _userManager.IsInRoleAsync(user.Id, "User"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    if (await _userManager.IsInRoleAsync(user.Id, "Manager"))
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                        //return Redirect("~/Admin/Home/Index");
                    }
                    if (await _userManager.IsInRoleAsync(user.Id, "Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                        //return Redirect("~/Admin/Home/Index");
                    }
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "User Not exists");

            if (loginViewModel == null)
            {
                loginViewModel = new LoginViewModel();
            }

            return View("Login", loginViewModel);
        }

        /// <summary>
        /// Get new user Registion page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="registerViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            // register functionality
            var user = new User()
            {
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email,
                FirstName = registerViewModel.Name,
                PasswordHash = registerViewModel.Password
            };
            //TODO handle error where register or add user but not expand that before insert
            var result = await _userManager.CreateAsync(user);

            if (result != null && result.Succeeded)
            {
                var userResult = await _signInManager.PasswordSignInAsync(user.Email, registerViewModel.Password, false, false);

                if (userResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            //TODO handle un authorised
            return RedirectToAction("Login");
        }

        /// <summary>
        /// Logout user
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Error and Access denide

        /// <summary>
        /// Error page
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Access denies
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult AccessDenied()
        {
            return View();
        }

        #endregion

        #region Reset password
        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="token"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            try
            {
                if (token == null || email == null)
                {
                    ModelState.AddModelError("message", "Invalid Token");
                }
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    ResetPasswordModel model = new ResetPasswordModel();
                    model.Email = email;
                    model.Email = token;
                    return View(model);

                }
                else
                {
                    ModelState.AddModelError("message", "Invalid user email");
                    return View();
                }
            }
            catch (Exception ex)
            {
                ex.Log();
                ModelState.AddModelError("message", "Invalid Token");
                return View();
            }
        }

        /// <summary>
        /// Reset password if forgot
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    bool isPassCorrect = (await _userManager.CheckPasswordAsync(user.Id, model.Password));
                    if (isPassCorrect == false)
                    {
                        var result = await _userManager.ResetPasswordAsync(user.Id, model.Token, model.Password);

                        if (result.Succeeded)
                        {
                            var token = await _userManager.GeneratePasswordResetTokenAsync(user.Id);
                            await _userManager.SaveToken(user.Id, "", true);
                            return View();
                        }
                        else
                        {
                            ModelState.AddModelError("message", result.Errors.FirstOrDefault());
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("message", "Old Password and New Password cannot be same");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("message", "Invalid Login Attempt");
                    return View(model);
                }
            }
            return View(model);
        }

        #endregion

        #region Public pages

        /// <summary>
        /// Site Term and condition
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> TermsAndCondition()
        {
            return View();
        }

        /// <summary>
        /// site privacy policy
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> PrivacyPolicy()
        {
            return View();
        }

        /// <summary>
        /// Site support page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Support()
        {
            return View();
        }

        #endregion
    }
}