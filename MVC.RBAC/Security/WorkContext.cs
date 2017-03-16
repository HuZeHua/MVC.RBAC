using MVC.RBAC.Entities;

namespace MVC.RBAC.Security
{
    public class WorkContext
    {
        public static User CurrentUser
        {
            get
            {
                return new AuthorizeProvider().GetAuthorizeUser();
            }
        }
    }
}