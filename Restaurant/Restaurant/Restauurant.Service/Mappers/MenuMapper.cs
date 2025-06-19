using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restauurant.Service.Mappers
{
    public class MenuMapper: Profile
    {
        public MenuMapper()
        {
            CreateMap<Restaurant.Core.Entities.Product, Restaurant.Core.DTOs.MenuDTO>();

        }
    }

}
