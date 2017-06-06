using BusinessLayerAccess.Interfaces;
using BusinessLayerAccess.Models;
using Domain.Entities;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Ullr.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAuthProvider _authProvider;
        private readonly IRepository<UserRegisterModel> _userRepository;

        public AccountController(IAuthProvider authProvider, IRepository<UserRegisterModel> userRepository)
        {
            _authProvider = authProvider;
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_authProvider.Authenticate(model.Name, model.Password))
                {
                    return View();
                    //return Redirect(Url.Action("ShowList", "Auctions"));
                }
                else
                {
                    ModelState.AddModelError("", @"Неправильный логин или пароль");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToRouteResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                Request.Cookies.Remove("UserId");
                FormsAuthentication.SignOut();

                return RedirectToAction("Register");
            }
            else
            {
                return RedirectToAction("Register");
            }
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRegisterModel user)
        {
            if (ModelState.IsValid)
            {
                if (_userRepository.Get().Any(u => u.UserName.Equals(user.UserName)))
                {
                    ViewBag.Message = "Пользователь с таким именем существует";
                }
                else
                {
                    _userRepository.Add(user);
                    ModelState.Clear();
                    user = null;
                    
                    ViewBag.Message = "Новый пользователь успешно зарегистрирован";
                }
            }
            return View(user);
        }        
	}
}