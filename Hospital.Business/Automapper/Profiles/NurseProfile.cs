using AutoMapper;
using Hospital.Entities.Concrete;
using Hospital.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Business.Automapper.Profiles
{
    public class NurseProfile : Profile
    {
        public NurseProfile()
        {
            CreateMap<NurseAddDto, Nurse>();
            CreateMap<NurseListDto, Nurse>();
            /*
            CreateMap<NurseAddDto, Nurse>().ForMember(dest=>dest.Gender,opt=>opt.MapFrom(x=>"Veri Yok"));
            CreateMap<NurseAddDto, Nurse>().ForMember(dest => dest.Description, opt => opt.MapFrom(x => "Veri Yok"));
            CreateMap<NurseAddDto, Nurse>().ForMember(dest => dest.Region, opt => opt.MapFrom(x => "Veri yok"));
            */
            
        }
    }
}
