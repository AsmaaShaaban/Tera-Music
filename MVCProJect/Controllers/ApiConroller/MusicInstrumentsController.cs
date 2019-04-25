using AutoMapper;
using MVCProJect.Dtos;
using MVCProJect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;

namespace MVCProJect.Controllers.ApiConroller
{
	public class MusicInstrumentsController : ApiController
	{
		private ApplicationDbContext _ctx;
		public MusicInstrumentsController()
		{
			_ctx = new ApplicationDbContext();
		}
		[HttpGet]
		public IEnumerable<MusicInstrumentDto> MusicInstruments(string query=null)
		{
			var musicQuery = _ctx.MusicInstruments.
				Include(c => c.Genre);
			if (!string.IsNullOrWhiteSpace(query))
				musicQuery = musicQuery.Where(m=>m.Name.Contains(query));
			var musicDto = musicQuery
				.ToList()
				.Select(Mapper.Map<MusicInstruments,MusicInstrumentDto>);
			return musicDto;
		}
		[HttpGet]

		public IHttpActionResult MusicInstrument(int Id)
		{
			var music = _ctx.MusicInstruments.SingleOrDefault(c => c.Id == Id);
			if (music == null)
				return NotFound();

			return Ok(Mapper.Map<MusicInstruments,MusicInstrumentDto>(music));
		}

		[HttpPost]
		public IHttpActionResult MusicInstrument(MusicInstrumentDto MusicInstrumentdto)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			var MusicInstrument = Mapper.Map<MusicInstrumentDto, MusicInstruments>(MusicInstrumentdto);
			_ctx.MusicInstruments.Add(MusicInstrument);
			_ctx.SaveChanges();
			return Created(new Uri (Request.RequestUri+"/"+ MusicInstrument.Id),MusicInstrument);
		}

		[HttpPut]
		public void UpdateMusicInstrument(int Id, MusicInstrumentDto MusicInstrumentdto)
		{
			var music = _ctx.MusicInstruments.SingleOrDefault(c => c.Id == Id);

			if (music == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);
			//using Auto mapper
			Mapper.Map(MusicInstrumentdto , music);

			//music.Name = MusicInstrument.Name;
			//music.InstructorName = MusicInstrument.InstructorName;
			//music.GenreId = MusicInstrument.GenreId;
			//music.CourseDuration = MusicInstrument.CourseDuration;
			_ctx.SaveChanges();
		}
		[HttpDelete]
		public void DeleteInstrument(int Id)
		{
			var music = _ctx.MusicInstruments.SingleOrDefault(c => c.Id == Id);

			if (music == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);
			_ctx.MusicInstruments.Remove(music);
			_ctx.SaveChanges();
		}



	}
}