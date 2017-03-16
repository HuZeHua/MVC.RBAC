using MVC.RBAC.Entities;
using MVC.RBAC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.RBAC.Controllers
{
    public class NavigateController : Controller
    {
        private XCodeContext db = new XCodeContext();

        private IEnityPermissionService entityPermissionService = new EnityPermissionService();
        // GET: Navigate
        public ActionResult Index()
        {
            var currentUserNavigates = db.Navigates.Where(nav => entityPermissionService.Authorize(nav));

            return View(currentUserNavigates);
        }
    }
}