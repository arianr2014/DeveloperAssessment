using AutoMapper;
using AreyesAssessment.API.DTOs;
using AreyesAssessment.Data.Entities;
using AreyesAssessment.Api.DTOs;

namespace AreyesAssessment.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Donor, DonorDto>().ReverseMap();
            CreateMap<Pledge, PledgeDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<ChangeLog, ChangelogDto>().ReverseMap();

            CreateMap<PledgePayment, PledgePaymentDto>()
             .ForMember(dest => dest.Pledge, opt => opt.MapFrom(src => src.Pledge))
             .ForMember(dest => dest.Payment, opt => opt.MapFrom(src => src.Payment));
        }
    }
}
