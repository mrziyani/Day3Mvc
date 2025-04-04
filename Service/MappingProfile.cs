using AutoMapper;
using DAL.Models;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping de Restaurant vers RestaurantDto et vice-versa
            CreateMap<Restaurant, RestaurantDto>().ReverseMap();
        }
    }
}
