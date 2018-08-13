using AcmeRemoteFilghts.CoreLayer.Extensions;
using AcmeRemoteFilghts.DataLayer.Entities;
using AcmeRemoteFilghts.PresentaionLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeRemoteFilghts.PresentaionLayer.Extensions
{
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        public static FlightViewModel ToModel(this Flight entity)
        {
            return entity.MapTo<Flight, FlightViewModel>();
        }
        public static Flight ToEntity(this FlightViewModel entity)
        {
            return entity.MapTo<FlightViewModel, Flight>();
        }

    }

}
