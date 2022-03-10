using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Services.IServices;
using Services.IServices.Identity;

namespace Web.Controllers.Base
{
    /// <summary>
    /// manager user
    /// </summary>
    [Authorize]
    public class ManageController : Controller
    {
        private readonly IUserService _userManager;
        private readonly ISignInService _signInManager;

        /// <summary>
        /// construct services
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        public ManageController(IUserService userManager, ISignInService signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// get user details
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// view user
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> UserView()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View(user);
        }
       
        /// <summary>
        /// changes user status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> ChangeStatus(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            user.IsActive = !user.IsActive;
            var result = await _userManager.UpdateAsync(user);
            return Json(new { flag = result.Succeeded });
        }
    }
}
