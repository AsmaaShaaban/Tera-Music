using AutoMapper;
using MVCProJect.Dtos;
using MVCProJect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProJect.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Customer,CustomerDto>();
			CreateMap<CustomerDto, Customer>()
				.ForMember(c => c.Id, opt => opt.Ignore());

			CreateMap<MusicInstruments, MusicInstrumentDto>();
			CreateMap<MusicInstrumentDto, MusicInstruments>()
				.ForMember(c => c.Id, opt => opt.Ignore());

			CreateMap<Membership, MembershipDto>();
			CreateMap<MembershipDto, Membership>()
				.ForMember(c => c.Id, opt => opt.Ignore());

			CreateMap<Genre, GenreDto>();
			CreateMap<GenreDto, Genre>()
				.ForMember(c=>c.Id,opt=>opt.Ignore());
		}
	}
}