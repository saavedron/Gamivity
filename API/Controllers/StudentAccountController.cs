using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class StudentAccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public StudentAccountController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;

        }

        [HttpPost("register")]
        public async Task<ActionResult<StudentDto>> Register(RegisterDto registerDto)
        {
            if (await StudentExists(registerDto.Username)) return BadRequest("username is taken");

            using var hmac = new HMACSHA512();

            var student = new Student
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return new StudentDto
            {
                Username = student.UserName,
                Token = _tokenService.CreateToken(student)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<StudentDto>> Login(LoginDto loginDto)
        {
            var student = await _context.Students.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);

            if (student == null) return Unauthorized("invalid student");

            using var hmac = new HMACSHA512(student.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != student.PasswordHash[i]) return Unauthorized("invalid password");
            }

            return new StudentDto
            {
                Username = student.UserName,
                Token = _tokenService.CreateToken(student)
            };
        }

        private async Task<bool> StudentExists(string username)
        {
            return await _context.Students.AnyAsync(x => x.UserName == username.ToLower());
        }

    }
}