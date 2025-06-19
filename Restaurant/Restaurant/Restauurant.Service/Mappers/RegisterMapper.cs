using AutoMapper;
using Restaurant.Core.DTOs.Account;
using Restaurant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restauurant.Service.Mappers
{
    public class RegisterMapper :Profile
    {
        public RegisterMapper() {
            CreateMap<RegisterDTO,Customer>().AfterMap((src, dest) =>
            {
                dest.Name = src.Name;
                dest.Email = src.Email;
                dest.Street = src.Address;
                dest.City = src.Address;
                dest.Governorate = src.Address;
                dest.Phone = src.Phone;
                dest.Password = src.Password;
            });
        }
    }
}
