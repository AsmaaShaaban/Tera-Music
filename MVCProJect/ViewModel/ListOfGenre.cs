using MVCProJect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProJect.ViewModel
{
	public class ListOfGenre
	{
		public IEnumerable<Genre> Genres { get; set; }
		public MusicInstruments Instrument { get; set; }

	}
}