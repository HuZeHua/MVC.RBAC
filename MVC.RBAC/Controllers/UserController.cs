using System.Linq;
using System.Web.Mvc;
using MVC.RBAC.Entities;
using MVC.RBAC.Models;
using MVC.RBAC.Security;

namespace MVC.RBAC.Controllers
{
    public class UserController : Controller
    {
        IAuthorizeProvider authorizeProvider = new AuthorizeProvider();
        private readonly XCodeContext db = new XCodeContext();
        public ActionResult Index()
        {
            return View(db.Users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (db.Users.Any(u => u.Name == model.UserName && u.Password == model.Password))
            {
                authorizeProvider.SignIn(new User { Name = model.UserName, Password = model.Password }, model.RememberMe);
                if (!string.IsNullOrWhiteSpace(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "无效的用户名或密码");
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult SignOut()
        {
            authorizeProvider.SignOut();
            return RedirectToAction(nameof(Login));
        }
    }
}