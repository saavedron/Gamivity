using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<GeneralClass> GeneralClasses { get; set; }
        public DbSet<Class> Classes { get; set; }

        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<BaseQuestion> BaseQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<StudentClass>()
                .HasKey(k => new { k.StudentId, k.ClassId });

            builder.Entity<StudentClass>()
                .HasOne(s => s.Student)
                .WithMany(c => c.StudentClasses)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            
            builder.Entity<ClassTest>()
                .HasKey(k => new { k.ClassId, k.TestId });

            builder.Entity<ClassTest>()
                .HasOne(s => s.Class)
                .WithMany(t => t.ClassTests)
                .HasForeignKey(s => s.ClassId)
                .OnDelete(DeleteBehavior.NoAction);

            

        }


    }
}