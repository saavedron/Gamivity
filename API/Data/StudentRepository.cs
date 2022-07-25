using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public StudentRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student> GetStudentByUsernameAsync(string username)
        {
            return await _context.Students.Include(c => c.StudentClasses).
                ThenInclude(c => c.Class).
                    ThenInclude(g => g.GeneralClass).
                        SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _context.Students.Include(c => c.StudentClasses).
                ThenInclude(c => c.Class).ThenInclude(g => g.GeneralClass).ToListAsync();
        }

        public async Task<StudentMemberDto> GetStudentMemberByUsernameAsync(string username)
        {
            return await _context.Students.
                Where(x => x.UserName == username)
                .ProjectTo<StudentMemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
        }
    }
}