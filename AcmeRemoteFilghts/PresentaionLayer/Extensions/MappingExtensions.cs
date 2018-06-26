using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AcmeRemoteFilghts.PresentaionLayer.Extensions
{
    public static class MappingExtensions
    {
        public static IMapper Mapper { get; private set; }

        /// <summary>
        /// Mapper configuration
        /// </summary>
        public static MapperConfiguration MapperConfiguration { get; private set; }

        /// <summary>
        /// Initialize mapper
        /// </summary>
        /// <param name="config">Mapper configuration</param>
        public static void Init(MapperConfiguration config)
        {
            MapperConfiguration = config;
            Mapper = config.CreateMapper();
        }
        /// <summary>
        /// Set to set
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static List<TResult> MapTo<TResult>(this IEnumerable self)
        {
            if (self == null)
                throw new ArgumentNullException();
            Mapper.Map(self.GetType(), typeof(TResult));
              return (List<TResult>)Mapper.Map(self, self.GetType(), typeof(List<TResult>));
        }
        /// <summary>
        /// Object to object
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static TResult MapTo<TResult>(this object self)
        {
            if (self == null)
                throw new ArgumentNullException();
            Mapper.Map(self.GetType(), typeof(TResult));
            return (TResult)Mapper.Map(self, self.GetType(), typeof(TResult));
        }

    }

   
}
