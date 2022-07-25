using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;
using API.DTOs;
using AutoMapper;

namespace API.Controllers
{
    [Authorize]
    public class StudentsController : BaseApiController
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentMemberDto>>> GetStudents()
        {
            var students = await _studentRepository.GetStudentsAsync();

            var studentsToReturn = _mapper.Map<IEnumerable<StudentMemberDto>>(students);
            return Ok(studentsToReturn);
        }


        [HttpGet("{username}")]
        public async Task<ActionResult<StudentMemberDto>> GetStudent(string username)
        {

            return await _studentRepository.GetStudentMemberByUsernameAsync(username);
        }


    }
}