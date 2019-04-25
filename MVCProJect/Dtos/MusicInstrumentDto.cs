using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProJect.Dtos
{
	public class MusicInstrumentDto
	{
		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		[StringLength(255)]
		public string InstructorName { get; set; }
		public byte CourseDuration { get; set; }

		public GenreDto Genre { get; set; }
		public byte GenreId { get; set; }
	}
}