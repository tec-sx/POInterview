using AutoMapper;
using POInterview.Application.Models;
using POInterview.Infrastructure.Data.Entities;

namespace POInterview.Application.Mapper;

internal sealed class BookingMappingProfile : Profile
{
    public BookingMappingProfile()
    {
        CreateMap<BookingDto, Booking>()
            .ForMember(dest => dest.Resource, opt => opt.Ignore())
            .ReverseMap();
    }
}
