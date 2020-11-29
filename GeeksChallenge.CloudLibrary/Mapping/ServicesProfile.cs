
using System;
using AutoMapper;
using GeeksChallenge.CloudLibrary.Dtos;
using GeeksChallenge.Domain.Models;

namespace GeeksChallenge.Application.Mapping
{
    public class ServicesProfile : AutoMapper.Profile
    {
        public ServicesProfile()
        {
            CreateMap<Service, ServicesReadDto>().ReverseMap();
            CreateMap<Service, ServicesUpsertDto>().ReverseMap();
            CreateMap<ServicesReadDto, ServicesUpsertDto>().ReverseMap();

            CreateMap<OptionDefaultValue, OptionDefaultValuesReadDto>().ReverseMap();
            CreateMap<OptionDefaultValue, OptionDefaultValuesUpsertDto>().ReverseMap();
            CreateMap<OptionDefaultValuesReadDto, OptionDefaultValuesUpsertDto>().ReverseMap();

            CreateMap<ServiceOption, ServiceOptionsReadDto>().ReverseMap();
            CreateMap<ServiceOption, ServiceOptionsUpsertDto>().ReverseMap();
            CreateMap<ServiceOptionsReadDto, ServiceOptionsUpsertDto>().ReverseMap();
        }
    }
}
