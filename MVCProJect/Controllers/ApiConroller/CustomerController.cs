using AutoMapper;
using MVCProJect.Dtos;
using MVCProJect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace MVCProJect.Controllers.ApiConroller
{
	public class CustomerController : ApiController
	{
		private ApplicationDbContext _ctx;
		public CustomerController()
		{
			_ctx = new ApplicationDbContext();
		}

		//GET Api/Customers
		[HttpGet]
		public IEnumerable<CustomerDto> GetAll(string query =null)
		{
			var CustomersQuery = _ctx.Customers
				.Include(c => c.Membership);
			if (!string.IsNullOrWhiteSpace(query))
				CustomersQuery = CustomersQuery.Where(c => c.Name.Contains(query));
			var CustomerDto = CustomersQuery
				.ToList()
				.Select(Mapper.Map<Customer,CustomerDto>);
			return CustomerDto;
		}
		[HttpGet]
		public IHttpActionResult GetCustomer(int Id)
		{
			var customer = _ctx.Customers.SingleOrDefault(c => c.Id == Id);
			if (customer == null)
			{
				return NotFound();
			}

			return Ok(Mapper.Map<Customer,CustomerDto> (customer));
		}

		[HttpPost]

		public IHttpActionResult PostCustomer(CustomerDto customerdto)
		{
			if (!ModelState.IsValid)

				return BadRequest();
			var customer = Mapper.Map<CustomerDto, Customer>(customerdto);
			_ctx.Customers.Add(customer);
			_ctx.SaveChanges();

			return Created(new Uri (Request.RequestUri+"/"+customer.Id),customerdto);

		}
		[HttpPut]
		public void UpdateCustomer(int Id, CustomerDto customerdto)

		{
			var customerInDB = _ctx.Customers.SingleOrDefault(c => c.Id == Id);

			if (customerInDB == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			if (!ModelState.IsValid)

				throw new HttpResponseException(HttpStatusCode.BadRequest);

			Mapper.Map(customerdto , customerInDB);

			//customerInDB.Name = customer.Name;
			//customerInDB.MembershipId = customer.MembershipId;
			//customerInDB.BirthDate = customer.BirthDate;
			//customerInDB.IsSubscribedToNewsLetters = customer.IsSubscribedToNewsLetters;
			_ctx.SaveChanges();
		}

			public void DeleteCustomer(int Id)

		{
			var customer = _ctx.Customers.SingleOrDefault(c => c.Id == Id);
			if (customer == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}

			_ctx.Customers.Remove(customer);
			_ctx.SaveChanges();
		}

    }
}
