
using SchoolProject.Core.Features.Students.Queries.Responses;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.StudentMapper
{
    public partial class StudentProfile
    {
        public void GetAllStudentsMapper()
        {
            CreateMap<Student, GetAllStudentsResponse>()
               .ForMember(dest => dest.DepartmentName, source => source.MapFrom(source => source.Department.Name));

        }
    }
}
