using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProJect.Dtos
{
	public class MembershipDto
	{
		public byte Id { get; set; }
		[StringLength(255)]
		public string Name { get; set; }
		public short SignUpFee { get; set; }
		
		public byte Duration { get; set; }
		public byte Discount { get; set; }
	}
}