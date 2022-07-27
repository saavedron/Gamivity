using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<GeneralClass, GeneralClassDto>();
            CreateMap<Student, StudentMemberDto>();
            CreateMap<StudentClass, StudentClassDto>();
            CreateMap<Class, ClassDto>();

            CreateMap<BaseQuestion, BaseQuestionDto>();




        }

    }
}