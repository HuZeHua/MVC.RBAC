using MVC.RBAC.Entities;

namespace MVC.RBAC.Security
{
    public interface IAuthorizeProvider
    {
        void SignIn(User user, bool rememberMe);

        void SignOut();

        User GetAuthorizeUser();
    }
}
