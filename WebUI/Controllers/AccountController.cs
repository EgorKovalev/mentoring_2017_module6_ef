using BusinessLayerAccess.Interfaces;
using BusinessLayerAccess.Models;
using Domain.Entities;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Wrapper;
using AutoMapper;

namespace Ullr.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAuthProvider _authProvider;
        private Repository _context = new Repository();

        public AccountController(IAuthProvider authProvider)
        {
            _authProvider = authProvider;            
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
                if (_context.UserRepository.Get().Any(u => u.Login.Equals(user.Login)))
                {
                    ViewBag.Message = "Пользователь с таким именем существует";
                }
                else
                {
                    var config = new MapperConfiguration(cfg => {
                        cfg.CreateMap<UserRegisterModel, User>();
                    });

                    IMapper mapper = config.CreateMapper();
                    var userEntity = mapper.Map<UserRegisterModel, User>(user);
                    
                    _context.UserRepository.Add(userEntity);
                    _context.CommitChanges();

                    ModelState.Clear();
                    user = null;
                    
                    ViewBag.Message = "Новый пользователь успешно зарегистрирован";
                }
            }
            return View(user);
        }        
	}
}