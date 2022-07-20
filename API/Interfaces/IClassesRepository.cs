using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IClassesRepository
    {
        Task<StudentClass> GetStudentClass(int studentId, int classId);
        Task<Student> GetStudentWithClasses(int studentId);

        Task<IEnumerable<ClassDto>> GetStudentClasses(int studentId);

        Task<ClassDto> GetClassByName(string name);




    }
}