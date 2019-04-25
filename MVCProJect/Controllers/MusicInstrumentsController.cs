using MVCProJect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MVCProJect.ViewModel;
using System.Runtime.Caching;

namespace MVCProJect.Controllers
{
    public class MusicInstrumentsController : Controller
	{
		private ApplicationDbContext _ctx;

		public MusicInstrumentsController()
		{
			_ctx = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_ctx.Dispose();
		}


		// GET: MusicInstruments
		public ActionResult Index()
        {
			if (User.IsInRole(RoleName.CanManageRoles))
				//var music = _ctx.MusicInstruments.Include(c=>c.Genre).ToList();
				return View("List");
			else
				return View("ReadOnlyList");

        }

		// GET: MusicInstruments/Details/Id
		public ActionResult Details(int Id)
		{
			var music = _ctx.MusicInstruments.Include(c =>c.Genre).SingleOrDefault(c=>c.Id == Id);
			if (music == null)
			{
				return HttpNotFound();
			}
			return View(music);

		}

		// GET: MusicInstrument/Create
		[Authorize(Roles = RoleName.CanManageRoles)]
		public ActionResult Create()
		{
			if (MemoryCache.Default["Genres"]==null)
			{
				MemoryCache.Default["Genres"] = _ctx.Genres.ToList();

			}
			var music = new ListOfGenre
			{
				Instrument = new MusicInstruments(),
				Genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>
			};
			return View(music);
		}

		// POST: MusicInstrument/CreateMusic
		[HttpPost]
		//[ValidateAntiForgeryToken]
		[Authorize(Roles = RoleName.CanManageRoles)]
		public ActionResult CreateMusic(MusicInstruments Instrument)
		{
			if (!ModelState.IsValid)
			{
				var music = new ListOfGenre
				{
					Instrument = Instrument,
					Genres = _ctx.Genres.ToList()
				};
				return View("Create", music);
			}
			if (Instrument.Id == 0)
			{
				_ctx.MusicInstruments.Add(Instrument);
			}
			else {
				var InstrumentInDB = _ctx.MusicInstruments.SingleOrDefault(c => c.Id == Instrument.Id);
				InstrumentInDB.Name = Instrument.Name;
				InstrumentInDB.GenreId = Instrument.GenreId;
				InstrumentInDB.CourseDuration = Instrument.CourseDuration;
				InstrumentInDB.InstructorName = Instrument.InstructorName;
			}
			_ctx.SaveChanges();
			return RedirectToAction("Index", "MusicInstruments");
		}

		// GET: MusicInstruments/Edit/Id
		[Authorize(Roles =RoleName.CanManageRoles)]
		public ActionResult Edit(int Id)
		{
			var music = _ctx.MusicInstruments.SingleOrDefault(c => c.Id == Id);
			if (music==null)
			{
				return HttpNotFound();

			}
			var viewmodel = new ListOfGenre
			{
				Instrument = music,
				Genres = _ctx.Genres.ToList()
			};
			return View("Create", viewmodel);
		}

		// GET: MusicInstruments/Delete/Id
		[Authorize(Roles = RoleName.CanManageRoles)]
		public ActionResult Delete(int Id)
		{
			var music = _ctx.MusicInstruments.SingleOrDefault(c=>c.Id==Id);
			if (music == null)
			{
				return HttpNotFound();
			}

			_ctx.MusicInstruments.Remove(music);
			_ctx.SaveChanges();
			return RedirectToAction("Index","MusicInstruments");
		}
	}
}