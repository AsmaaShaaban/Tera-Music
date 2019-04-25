using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProJect.Models
{
	public class Customer
	{
		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime? BirthDate { get; set; }

		public bool IsSubscribedToNewsLetters { get; set; }

		public Membership Membership { get; set; }

		[Display (Name="Membership Type")]
		public byte MembershipId { get; set; }

	}
}