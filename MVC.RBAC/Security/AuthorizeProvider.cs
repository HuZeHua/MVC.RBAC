using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using MVC.RBAC.Entities;

namespace MVC.RBAC.Security
{
    public class AuthorizeProvider : IAuthorizeProvider
    {
        XCodeContext db = new XCodeContext();

        public User GetAuthorizeUser()
        {
            HttpContext httpContext = HttpContext.Current;
            if (httpContext != null && httpContext.Request != null && httpContext.Request.IsAuthenticated && (httpContext.User.Identity is FormsIdentity))
            {
                FormsIdentity formIdentity = (FormsIdentity)httpContext.User.Identity;
                string userName = formIdentity.Ticket.Name;
                string userData = formIdentity.Ticket.UserData;
                if (!string.IsNullOrWhiteSpace(userName))
                {
                    return db.Users.SingleOrDefault(u => u.Name == userName);
                }
            }

            return null;
        }

        public void SignIn(User user, bool rememberMe)
        {
            string userData = Guid.NewGuid().ToString();
            var ticket = new FormsAuthenticationTicket(1, user.Name, DateTime.Now, DateTime.Now.AddDays(1), rememberMe, userData);
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket) { HttpOnly = true };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}