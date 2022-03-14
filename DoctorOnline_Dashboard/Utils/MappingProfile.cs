using AutoMapper;
using DoctorOnline_Dashboard.ModelDto;
using DoctorOnline_Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientDto>();
            CreateMap<PatientDto, Patient>();

            CreateMap<Speciality, SpecialityDto>();
            CreateMap<SpecialityDto, Speciality>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
        }
      

    }
}
