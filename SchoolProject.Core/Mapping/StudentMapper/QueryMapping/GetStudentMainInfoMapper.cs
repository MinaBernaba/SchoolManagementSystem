
using SchoolProject.Core.Features.Students.Queries.Responses;
using SchoolProject.Data.Entities.DbTables;

namespace SchoolProject.Core.Mapping.StudentMapper
{
    public partial class StudentProfile
    {
        public void GetAllStudentsMapper()
        {
            CreateMap<Student, GetStudentMainInfoResponse>()
               .ForMember(dest => dest.DepartmentName, source => source.MapFrom(source => source.Department.Name))
               .ReverseMap();

        }
    }
}
