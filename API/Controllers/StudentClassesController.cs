using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class StudentClassesController : BaseApiController
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassesRepository _classesRepository;
        public StudentClassesController(IStudentRepository studentRepository, IClassesRepository classesRepository)
        {
            _classesRepository = classesRepository;
            _studentRepository = studentRepository;
        }

        [HttpPost("{name}")]
        public async Task<ActionResult> AddStudentToClass(string name)
        {
            var studentId = User.GetStudentId();
            var _class = await _classesRepository.GetClassByName(name);
            var student = await _classesRepository.GetStudentWithClasses(studentId);

            if (_class == null) return NotFound();

            var studentClass = await _classesRepository.GetStudentClass(studentId, _class.Id);

            if (studentClass != null) return BadRequest("Cannot join to class (already joined)");

            studentClass = new StudentClass
            {
                StudentId = studentId,
                ClassId = _class.Id
            };

            student.StudentClasses.Add(studentClass);

            if (await _studentRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed joinind student");

        }
    }
}