using AutoMapper;
using FluentValidationAndAutoMapper.Entity;
using FluentValidationAndAutoMapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationAndAutoMapper.Profiles
{
    internal class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarBindingModel, Car>();
        }
    }
}
