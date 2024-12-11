using AutoMapper;
using VarsityManagementAPI.DTOs;
using VarsityManagementAPI.Models;

namespace VarsityManagementAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Course, CourseDTO>();
            CreateMap<CourseDTO, Course>();
            CreateMap<Module, ModuleDTO>();
            CreateMap<ModuleDTO,  Module>();
            CreateMap<Faculty, FacultyDTO>();
            CreateMap<FacultyDTO, Faculty>();
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();
        }
    }
}
