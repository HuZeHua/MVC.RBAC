using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MVC.RBAC.Entities;

namespace MVC.RBAC.Controllers
{
    public class RoleController : Controller
    {
        private readonly XCodeContext db=new XCodeContext();
        public ActionResult Index()
        {
            return View(db.Roles);
        }

        public ActionResult Authorize(int id)
        {
            Role role = db.Roles.Find(id);
            var groups = db.Permissions.GroupBy(p => p.Category);
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var group in groups)
            {
                var selectListGroup = new SelectListGroup { Name = group.Key };

                selectListItems.AddRange(group.Select(g => new SelectListItem
                {
                    Group = selectListGroup,
                    Selected = role.Permissions.Any(rp => rp.ID == g.ID),
                    Value = g.ID.ToString(),
                    Text = g.Description
                }));
            }

            return View(new SelectList(selectListItems));
        }

        [HttpPost]
        public ActionResult Authorize(int id, IEnumerable<int> permissionIds)
        {
            permissionIds = permissionIds ?? Enumerable.Empty<int>();
            Role role = db.Roles.Find(id);

            role.Permissions.ToList().ForEach(p => role.Permissions.Remove(p));

            permissionIds.ToList().ForEach(pid =>
            {
                if (role.Permissions.All(rp => rp.ID != pid))
                {
                    role.Permissions.Add(db.Permissions.Find(pid));
                }
            });

            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Role role)
        {
            db.Roles.Add(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}