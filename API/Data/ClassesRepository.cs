using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ClassesRepository : IClassesRepository
    {
        private readonly DataContext _context;
        public ClassesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ClassDto> GetClassByName(string name)
        {
            var _class = await _context.Classes.FirstOrDefaultAsync(c => c.Name == name);
            return new ClassDto
            {
                Id = _class.Id,
                Name = _class.Name
            };
        }

        public async Task<StudentClass> GetStudentClass(int studentId, int classID)
        {
            return await _context.StudentClasses.FindAsync(studentId, classID);
        }



        public async Task<IEnumerable<ClassDto>> GetStudentClasses(int studentId)
        {
            var students = _context.Students.AsQueryable();
            var studentClasses = _context.StudentClasses.AsQueryable();

            studentClasses = studentClasses.Where(s => s.StudentId == studentId);
            var classes = studentClasses.Select(c => c.Class);


            return await classes.Select(c => new ClassDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToListAsync();
        }

        public async Task<Student> GetStudentWithClasses(int studentId)
        {
            return await _context.Students.Include(x => x.StudentClasses).FirstOrDefaultAsync(x => x.Id == studentId);
        }
    }
}