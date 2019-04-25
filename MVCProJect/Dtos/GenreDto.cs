using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProJect.Dtos
{
	public class GenreDto
	{
		public byte Id { get; set; }

		[StringLength(255)]
		public string Type { get; set; }
	}
}