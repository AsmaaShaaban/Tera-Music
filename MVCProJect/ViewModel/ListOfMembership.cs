using MVCProJect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProJect.ViewModel
{
	public class ListOfMembership
	{
		public IEnumerable<Membership> Memberships{ get; set; }
		public Customer Customer { get; set; }

	}
}