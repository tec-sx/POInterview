﻿using AutoMapper;
using POInterview.Application.Models;
using POInterview.Infrastructure.Data.Entities;

namespace POInterview.Application.Mapper;

internal sealed class ResourceMappingProfile : Profile
{
    public ResourceMappingProfile()
    {
        CreateMap<Resource, ResourceDto>();
        CreateMap<ResourceDto, Resource>();
    }
}
