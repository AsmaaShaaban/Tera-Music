﻿using MVCProJect.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProJect.Dtos
{
	public class CustomerDto
	{

		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime? BirthDate { get; set; }

		public MembershipDto Membership { get; set; }

		public bool IsSubscribedToNewsLetters { get; set; }

		[Display(Name = "membership types")]
		public byte MembershipId { get; set; }

}
}