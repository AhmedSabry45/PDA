using PDA.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PDA.Models;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace PDA.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUserManager _userManager;
        public UserController(ILogger<HomeController> logger, IConfiguration configuration ,IUserManager userManager)
        {
            _logger = logger;
            _configuration = configuration;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            string? message = TempData["LoginExpired"] as string;
            ViewBag.LoginExpired = message;
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            try
            {
                //var result = _userManager.IsUserAuthenticated(model.UserName, model.Password);
                var result = _userManager.IsUserAuthenticated(_configuration["DOMAIN"], model.UserName, model.Password);
               // if (!result.IsAuthenticated ||!result.IsAuthorized)
                if (!result.IsAuthenticated)
                    {
                    ViewBag.LoginError = result!.Message;
                    return View();
                }
                HttpContext.Session.SetString("userName", model.UserName.ToUpper());
                Console.WriteLine("UserName: " + HttpContext.Session.GetString("userName"));
                return RedirectToAction("search", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError($"error message: {ex.Message}");
                _logger.LogError($"error stack trace: {ex.StackTrace}");
                _logger.LogError($"source of error: {ex.Source}");
                return View();
            }
        }






        private static (bool IsDisabled, string Message) IsUserDisabled(string username)
        {
            (bool IsDisabled, string Message) result = (false, null);

            using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username);

                if (user != null)
                {
                    bool isDisabled = (!user?.Enabled) ?? true;  // Check if the user account is disabled

                    result = isDisabled ? (true, $"هذ المستخدم تم غلقه من فضلك قم بالتواصل مع قسم تكنولوجيا المعلومات") : (false, "");

                    return result;
                }
                else
                {
                    result = (true, $"لم يتم العثور علي هذا المستخدم");
                    return result;
                }
            }
        }

        private static (bool IsLocked, string Message) IsUserLockedOut(string username)
        {
            (bool IsLocked, string Message) result = (false, null);
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username);

                if (user != null)
                {
                    bool isLockedOut = user.IsAccountLockedOut();  // Check if the user account is locked

                    result = isLockedOut ? (true, $"هذا المستخدم تم تعليقه من فضلك قم بالتواصل مع قسم تكنولوجيا المعلومات") : (false, "");

                    return result;
                }
                else
                {
                    result = (true, $"لم يتم العثور علي هذا المستخدم");
                    return result;
                }
            }
        }

      


        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}