using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        //TODO: CHANGE THIS 
        //Seed data placeholder 
        public static async Task SeedStudents(DataContext context)
        {

            if (await context.Students.AnyAsync()) return;

            var studentData = await System.IO.File.ReadAllTextAsync("Data/SeedDataStudent.json");
            var students = JsonSerializer.Deserialize<List<Student>>(studentData);

            var generalClassData = await System.IO.File.ReadAllTextAsync("Data/SeedDataGeneralClass.json");
            var generalClasses = JsonSerializer.Deserialize<List<GeneralClass>>(generalClassData);

            var classData = await System.IO.File.ReadAllTextAsync("Data/SeedDataClass.json");
            var classes = JsonSerializer.Deserialize<List<Class>>(classData);

            foreach (var _class in classes)
            {
                _class.GeneralClass = generalClasses[0];
            }
            foreach (var student in students)
            {
                using var hmac = new HMACSHA512();

                student.UserName = student.UserName.ToLower();
                student.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("sus"));
                student.PasswordSalt = hmac.Key;
                // student.Classes = classes;
                context.Students.Add(student);
            }



            if (await context.Classes.AnyAsync()) return;
            context.Classes.AddRange(classes);

            await context.SaveChangesAsync();

        }



    }
}