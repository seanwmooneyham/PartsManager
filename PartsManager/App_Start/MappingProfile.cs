using AutoMapper;
using PartsManager.DTOs;
using PartsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartsManager.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateMap is a generic method that takes two parameters, <source, target>
            // when the method is called, automapper uses reflection to scan these types, finds the properties and maps them
            // based on their name.
            // Customer Mapping
            Mapper.CreateMap<Part, PartDto>();
            // ignores Part.Id when mapping PartDto to Part
            Mapper.CreateMap<PartDto, Part>().ForMember(p => p.Id, opt => opt.Ignore()); ;
        }
       
    }
}