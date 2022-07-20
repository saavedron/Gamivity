using System.Security.Claims;

namespace API.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static string GetUsername(this ClaimsPrincipal student)
        {
            return student.FindFirst(ClaimTypes.Name)?.Value;
        }

        public static int GetStudentId(this ClaimsPrincipal student)
        {
            return int.Parse(student.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}