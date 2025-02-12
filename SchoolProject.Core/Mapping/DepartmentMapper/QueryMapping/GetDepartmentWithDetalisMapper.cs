using SchoolProject.Core.CQRS.Departments.Queries.Responses;
using SchoolProject.Data.Entities.DbTables;

namespace SchoolProject.Core.Mapping.DepartmentMapper
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentByIdWithDetails()
        {
            CreateMap<Department, GetDepartmentByIdWithDetailsResponse>()
                    .ForMember(x => x.ManagerName, source => source.MapFrom(source => source.InstructorManager.Name))
                    //.ForMember(x => x.StudentsList, source => source.MapFrom(source => source.Students))
                    .ForMember(x => x.InstructorsList, source => source.MapFrom(source => source.Instructors))
                    .ForMember(x => x.SubjectsList, source => source.MapFrom(source => source.DepartmentSubjects));

            CreateMap<DepartmentSubject, SubjectResponse>()
                .ForMember(dest => dest.Id, source => source.MapFrom(source => source.SubjectId))
                .ForMember(dest => dest.SubjectName, source => source.MapFrom(source => source.Subject.Name));

            CreateMap<Instructor, InstructorResponse>();
            //CreateMap<Student, StudentResponse>();
        }
    }
}
