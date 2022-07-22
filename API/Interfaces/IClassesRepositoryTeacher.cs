using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;

namespace API.Interfaces
{
    public interface IClassesRepositoryTeacher
    {
        Task<ClassDto> GetTeacherClasses(int teacherId);
    }
}