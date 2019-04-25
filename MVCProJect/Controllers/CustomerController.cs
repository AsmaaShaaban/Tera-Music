using MVCProJect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MVCProJect.ViewModel;

namespace MVCProJect.Controllers
{
    public class CustomerController : Controller
    {
		private ApplicationDbContext _ctx;
		public CustomerController()
		{
			_ctx = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_ctx.Dispose();
		}

		// GET: Customer
		public ActionResult Index()
        {
			//	var customer = _ctx.Customers.ToList();
			//return View(customer);
			if (User.IsInRole(RoleName.CanManageRoles))
				return View("List");
			else
				return View("ReedOnlyList");
		}

		// GET: Customer/Create
		public ActionResult Create()
			{
				var viewmodel = new ListOfMembership
				{
					Memberships = _ctx.Memberships.ToList()
				};
			return View(viewmodel);
		}

		// POST: Customer/CreateCustomer
		[HttpPost]
		//[ValidateAntiForgeryToken]
		[Authorize(Roles = RoleName.CanManageRoles)]
		public ActionResult CreateCustomer(Customer customer)
		{
			if (customer.Id == 0)
			{
				_ctx.Customers.Add(customer);
			}
			else
			{
				var customerinDB = _ctx.Customers.SingleOrDefault(c => c.Id == customer.Id);
				customerinDB.Name = customer.Name;
				customerinDB.IsSubscribedToNewsLetters = customer.IsSubscribedToNewsLetters;
				customerinDB.BirthDate = customer.BirthDate;
				customerinDB.MembershipId = customer.MembershipId;

			}
			_ctx.SaveChanges();
			return RedirectToAction("Index", "Customer");
		}

		// GET: Customer/Details/Id
		public ActionResult Details(int Id)
		{
			var customer = _ctx.Customers.Include(c=>c.Membership).SingleOrDefault(c => c.Id == Id);
			if (customer == null)
			{
				return HttpNotFound();
			}
			return View(customer);
		
		}

		// GET: Customer/Edit/Id
		[Authorize(Roles =RoleName.CanManageRoles)]
		public ActionResult Edit(int Id)
		{
			var customer = _ctx.Customers.SingleOrDefault(c => c.Id == Id);
			if (customer==null) {
				return HttpNotFound();
			}
			var viewmodel = new ListOfMembership
			{
				Customer = customer,
				Memberships = _ctx.Memberships.ToList()
			};
			return View("create",viewmodel);
		}

		// GET: Customer/Delete/Id
		[Authorize(Roles = RoleName.CanManageRoles)]
		public ActionResult Delete(int Id)
		{
			var customer = _ctx.Customers.SingleOrDefault(c=>c.Id==Id);
			if (customer==null) {
				return HttpNotFound();
			}
			_ctx.Customers.Remove(customer);
			_ctx.SaveChanges();
			return RedirectToAction("Index","Customer");
		}
    }
}