using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Resources;

namespace BasicBilling.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBillingResource, Billing>();
            CreateMap<Billing, BillingDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.BillingCategory.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.BillingStatus.Name))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Client.Name));
        }
    }
}
