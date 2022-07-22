using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(List<Claim> claims);
        string CreateTokenStudent(Student student);
        string CreateTokenTeacher(Teacher teacher);


    }
}