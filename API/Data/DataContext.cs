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
        public DbSet<Class> Classes { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }

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
        }


    }
}