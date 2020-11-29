using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeeksChallenge.CloudLibrary.Dtos;
using GeeksChallenge.Domain.Models;

namespace GeeksChallenge.CloudLibrary.Mapping
{
    public class InfrastructureProfile : AutoMapper.Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<InfrastructureUpsertDto, Infrastructure>();
            CreateMap<Infrastructure, InfrastructureUpsertDto>();

            CreateMap<InfrastructureResourceUpsertDto, InfrastructureResource>();
            CreateMap<InfrastructureResource, InfrastructureResourceUpsertDto>();

            CreateMap<InfrastructureResourceOptionUpsertDto, InfrastructureResourceOption>();
            CreateMap<InfrastructureResourceOption, InfrastructureResourceOptionUpsertDto>();
        }
    }
}
