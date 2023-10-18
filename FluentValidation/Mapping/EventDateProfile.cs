using AutoMapper;
using FluentValidationApp.DTOs;
using FluentValidationApp.Entities;

namespace FluentValidationApp.Mapping
{
    public class EventDateProfile : Profile
    {
        public EventDateProfile()
        {
            CreateMap<EventDateDto, EventDate>().ForMember(x => x.Date, option => option.MapFrom(x => new DateTime(x.Year, x.Month, x.Day)));

            CreateMap<EventDate,EventDateDto>()
                .ForMember(x=>x.Year,option=>option.MapFrom(x=>x.Date.Year))
                .ForMember(x => x.Month, option => option.MapFrom(x => x.Date.Month))
                .ForMember(x => x.Day, option => option.MapFrom(x => x.Date.Day));
        }
    }
}
