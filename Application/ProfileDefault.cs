using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using AutoMapper;
using Entities;


using Microsoft.Data.SqlClient;

namespace Application
{
    public class ProfileDefault : Profile
    {
        public ProfileDefault()
        {
            CreateMap<Employee, EmployeeDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EmployeeId))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Fornavn))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Etternavn))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Adresse))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Telefonnr));
        }

    }
}
