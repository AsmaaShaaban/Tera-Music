using MVCProJect.Dtos;
using MVCProJect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCProJect.Controllers.ApiConroller
{
    public class UMLController : ApiController
    {
		
			private ApplicationDbContext _ctx;

			public UMLController ()
			{
				_ctx = new ApplicationDbContext();
			}

		[HttpPost]
		public IHttpActionResult NewUML(UMLDto UML)
		{
			var customer = _ctx.Customers
				.SingleOrDefault(c => c.Id == UML.CustomerId);
			if (customer == null)
				return BadRequest("Customer ID Not Found ..");

			var musics = _ctx.MusicInstruments
				.Where(c => UML.MusicId.Contains(c.Id)).ToList();

			foreach (var music in musics)
			{

				var uml = new UML
				{
					Customer = customer,
					MusicInstrument = music
					
				};
				_ctx.UML.Add(uml);
			}

			_ctx.SaveChanges();
			return Ok();
		}

	}
	
}
