using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ClassesRepository : IClassesRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ClassesRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> UpdateAndSaveGeneralClass(GeneralClass generalClass)
        {
            _context.GeneralClasses.Update(generalClass);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Class> GetClassByName(string name)
        {
            return await _context.Classes.Include(g => g.ClassTests).FirstOrDefaultAsync(c => c.Name == name);
            /* return new Class
             {
                 Id = _class.Id,
                 Name = _class.Name,
                 GeneralClassId = _class.GeneralClassId
             };*/
        }

        public async Task<StudentClass> GetStudentClass(int studentId, int classID)
        {
            return await _context.StudentClasses.FindAsync(studentId, classID);
        }



        public async Task<IEnumerable<ClassDto>> GetStudentClasses(int studentId)
        {
            var studentClasses = _context.StudentClasses.AsQueryable();

            studentClasses = studentClasses.Where(s => s.StudentId == studentId);

            var classes = studentClasses.Select(c => c.Class);


            return await classes.Select(c => new ClassDto
            {
                Id = c.Id,
                Name = c.Name,
                GeneralClass = _mapper.Map<GeneralClassDto>(c.GeneralClass)
            }).ToListAsync();
        }

        public async Task<Student> GetStudentWithClasses(int studentId)
        {
            return await _context.Students.Include(x => x.StudentClasses).FirstOrDefaultAsync(x => x.Id == studentId);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}