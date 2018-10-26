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
