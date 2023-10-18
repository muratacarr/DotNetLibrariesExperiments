using AutoMapper;
using FluentValidationApp.DTOs;
using FluentValidationApp.Entities;

namespace FluentValidationApp.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
       
            CreateMap<Customer, CustomerDto>().ReverseMap();

            //Proplarda kendimi maplemek istersek
            //CreateMap<Customer, CustomerDto>().ForMember(dest=>dest.Name,opt=>opt.MapFrom(x=>x.Name));

            //kompleks classlarda yani içinde başka bir class barındıran classlarda mapleme
            //CreateMap<Customer, CustomerDto>().ForMember(dest=>dest.CCValidDate,opt=>opt.MapFrom(x=>x.CreditCard.ValidDate));
            
            //
            //CreateMap<CreditCard, CustomerDto>();
            //CreateMap<Customer, CustomerDto>().IncludeMembers(x => x.CreditCard)
            
        }
    }
}
