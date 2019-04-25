using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProJect.Models
{
	public class MusicInstruments
	{
		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		[StringLength(255)]
		public string InstructorName { get; set; }
		public byte CourseDuration { get; set; }
		public Genre Genre { get; set; }

		[Display(Name = "Instrument Type")]
		public byte GenreId { get; set; }
	}
}