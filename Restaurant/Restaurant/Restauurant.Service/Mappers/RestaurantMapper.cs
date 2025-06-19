using AutoMapper;
using Restaurant.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restauurant.Service.Mappers
{
    public class RestaurantMapper: Profile
    {
        public RestaurantMapper()
        {
            CreateMap<Restaurant.Core.Entities.Restaurant, Restaurant.Core.DTOs.RestaurantDTO>()
               .ForMember(dest => dest.NumberOfFavorites,
                   opt => opt.MapFrom(src => src.CustomerRestaurants != null ? src.CustomerRestaurants.Count : 0))
               .ForMember(dest => dest.NumberOfReviews,
                   opt => opt.MapFrom(src => src.Reviews != null ? src.Reviews.Count : 0));

            CreateMap<Restaurant.Core.Entities.Restaurant, AddressDTO>().AfterMap((src, dest) =>
            {
                dest.Address = $"{src.Street}, {src.City}, {src.Governorate}";
            });
        }
    }
    

}
