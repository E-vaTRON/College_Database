using College_Database.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace College_Database.Core.Database
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity
                    .HasOne(ba => ba.Student)
                    .WithOne(ba => ba.User);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity
                    .HasOne(ba => ba.Student)
                    .WithMany(a => a!.StudentCourses)
                    .HasForeignKey(ba => ba.StudentID)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                entity
                    .HasOne(ba => ba.Course)
                    .WithMany(a => a!.StudentCourses)
                    .HasForeignKey(ba => ba.CourseID)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });


        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instuctor> Instuctors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<User> Users { get; set; }
    }

}
