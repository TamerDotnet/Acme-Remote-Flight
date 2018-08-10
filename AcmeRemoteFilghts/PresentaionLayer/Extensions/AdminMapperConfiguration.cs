using AcmeRemoteFilghts.CoreLayer.Extensions;
using AcmeRemoteFilghts.CoreLayer.Infrastructure;
using AcmeRemoteFilghts.CoreLayer.Parameters;
using AcmeRemoteFilghts.DataLayer.Entities;
using AcmeRemoteFilghts.PresentaionLayer.Models;
using AutoMapper;
using System.Collections.Generic;
namespace AcmeRemoteFilghts.PresentaionLayer.Extensions
{
    public class AdminMapperConfiguration : Profile, IMapperProfile
    {

        public AdminMapperConfiguration()
        {
            CreateMap<FlightResourceParameters, Flight>()
                .ForMember(dest => dest.CityFrom, mo => mo.Ignore())
                .ForMember(dest => dest.CityTo, mo => mo.Ignore())
                .ForMember(dest => dest.DepartTime, mo => mo.Ignore())
                .ForMember(dest => dest.MaxPassangers, mo => mo.Ignore());


            CreateMap<FlightViewModel, Flight>()
                .ForMember(dest => dest.CityFrom, mo => mo.Ignore())
                 .ForMember(dest => dest.CityTo, mo => mo.Ignore())
                .ForMember(dest => dest.DepartTime, mo => mo.Ignore())
                .ForMember(dest => dest.MaxPassangers, mo => mo.Ignore());
        }

        public int Order => 0;

    }
}



