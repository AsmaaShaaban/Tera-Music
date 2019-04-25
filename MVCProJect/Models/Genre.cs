using System.ComponentModel.DataAnnotations;

namespace MVCProJect.Models
{
	public class Genre
	{
		public byte Id { get; set; }
		
		[StringLength(255)]
		public string Type { get; set; }
	}
}