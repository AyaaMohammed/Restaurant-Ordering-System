using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restauurant.Service.Mappers
{
    public class CustomerMapper:Profile
    {
        public CustomerMapper() {
            CreateMap<Restaurant.Core.Entities.Customer, Restaurant.Core.DTOs.CustomerDataDTO>().AfterMap((src, dest) =>
            {
                dest.Name = src.Name;
                dest.Email = src.Email;
                dest.Phone = src.Phone;
                dest.Governorate = src.Governorate;
                dest.City = src.City;
                dest.Street = src.Street;
            }).ReverseMap();
    
        }
    }
}
