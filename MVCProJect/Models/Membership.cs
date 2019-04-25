using System.ComponentModel.DataAnnotations;

namespace MVCProJect.Models
{
	public class Membership
	{
		public byte Id { get; set; }
		[StringLength(255)]
		public string Name { get; set; }
		public short SignUpFee { get; set; }
		public byte Duration { get; set; }
		public byte Discount { get; set; }
	}
}