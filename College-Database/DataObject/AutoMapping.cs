using AutoMapper;
using College_Database.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College_Database.DataObject
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Course, CourseDTO>()
                .ReverseMap()
                .ForMember(d => d.CourseID, o => o.Ignore())
                .ForMember(d => d.Department, o => o.Ignore())
                .ForMember(d => d.Intructor, o => o.Ignore())
                .ForMember(d => d.StudentCourses, o => o.Ignore());

            CreateMap<Student, StudentDTO>()
                .ReverseMap()
                .ForMember(d => d.StudentID, o => o.Ignore())
                .ForMember(d => d.Birthday, o => o.Ignore())
                .ForMember(d => d.User, o => o.Ignore())
                .ForMember(d => d.StudentCourses, o => o.Ignore());

            CreateMap<Instuctor, InstructorDTO>()
                .ReverseMap()
                .ForMember(d => d.IntructorID, o => o.Ignore())
                .ForMember(d => d.Age, o => o.Ignore())
                .ForMember(d => d.Courses, o => o.Ignore())
                .ForMember(d => d.Department, o => o.Ignore());

            CreateMap<Department, DepartmentDTO>()
                .ReverseMap()
                .ForMember(d => d.DepartmentID, o => o.Ignore())
                .ForMember(d => d.Instuctors, o => o.Ignore())
                .ForMember(d => d.Courses, o => o.Ignore());
        }
    }
}
