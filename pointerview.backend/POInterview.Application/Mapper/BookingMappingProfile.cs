using AutoMapper;
using POInterview.Application.Models;
using POInterview.Infrastructure.Data.Entities;

namespace POInterview.Application.Mapper;

internal sealed class BookingMappingProfile : Profile
{
    public BookingMappingProfile()
    {
        CreateMap<Booking, BookingDto>()
            .ForMember(dest => dest.ResourceId, opt => opt.MapFrom(src => src.Resource.Id));
        CreateMap<BookingDto, Booking>()
            .ForMember(dest => dest.Resource, opt => opt.Ignore());
    }
}
