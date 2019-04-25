using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProJect.Models
{
	public class UML
	{
		public int Id { get; set; }
		public Customer Customer { get; set; }
		public MusicInstruments MusicInstrument { get; set; }
	}
}