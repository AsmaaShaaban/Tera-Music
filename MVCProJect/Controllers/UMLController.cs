using MVCProJect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProJect.Controllers
{
	[Authorize(Roles = RoleName.CanManageRoles)]
	public class UMLController : Controller
    {
        // GET: UML
        public ActionResult Index()
        {
            return View();
        }
    }
}