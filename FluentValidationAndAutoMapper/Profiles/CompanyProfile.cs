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
    internal class CompanyProfile : Profile
    {
        public CompanyProfile() 
        {
            CreateMap<CompanyBindingModel, Company>();

            CreateMap<Company, CompanyViewModel>().ForMember(x => x.EmailAndPhone , opt => opt.MapFrom(y => ConcatStrings(y)));
        }

        private string ConcatStrings(Company company)
        {
            if (string.IsNullOrEmpty(company.Phone))
            {
                return company.Email + " | No Phone";
            }
            var phone = "+" + company.Phone[0..3] + " (" + company.Phone[3..5] + ") " + company.Phone[5..8] + " " + company.Phone[8..10] + " " + company.Phone[10..12];

            return company.Email + " | " + phone;
        }
    }
}
