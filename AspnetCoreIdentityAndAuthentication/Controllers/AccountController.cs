using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AspnetCoreIdentityAndAuthentication.Models;
using Microsoft.AspNetCore.Authorization;
using AspnetCoreIdentityAndAuthentication.Models.AccountViewModels;
using Microsoft.Extensions.Logging;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspnetCoreIdentityAndAuthentication.Controllers
{
    public class AccountController 
        : Controller
    {

        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly ILogger _logger;


        public AccountController(UserManager<CustomUser> userManager,
                                 SignInManager<CustomUser> signInManager,
                                 ILogger logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;

        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                CustomUser user = new CustomUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User Created a new account with password");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User Created a new account with password");
                    return RedirectToLocal(returnUrl);
                }

                AddErrors(result);
            }
            return View(model);
        }



        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var err in result.Errors)
            {
                ModelState.AddModelError(string.Empty, err.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
                return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        #endregion



        /*
          UserManager<TUser> is a concrete class that manages the user.It is defined in the Microsoft.Extensions.Identity.Core namespace
          This class creates ,updates, and Deletes the Users.It has methods to find a user By UserId, UserName ,and Email.It also provides
          the functionality for adding Claims, removing Claims, add and removing roles,etc. It also generates password hash,Validate Users etc.

          Singin Manager is responsible for authenticating a user ,i.e signing in and sign out a user.It issues the authentication cookie to the user.

         */
    }
}
