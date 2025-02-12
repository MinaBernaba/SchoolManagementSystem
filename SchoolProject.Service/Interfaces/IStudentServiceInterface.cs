using SchoolProject.Data.Entities.DbTables;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Service.Interfaces
{
    public interface IStudentService
    {
        IQueryable<Student> GetAllStudentsIQueryable();
        IQueryable<Student> GetAllStudentsOfCertainDepartmentIQueryable(int departmentID);
        IQueryable<Student> GetAllStudentsWithDepartmentIQueryable();
        IQueryable<Student> FilterStudentsIQueryable(EnStudentOrdering orderBy, string search);
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task AddAsync(Student student);
        Task<bool> IsStudentNameExistAsync(string name);
        Task<bool> IsStudentExistByIdAsync(int id);
        Task UpdateStudentAsync(Student student);
        Task<bool> IsStudentNameExistExceptSelfAsync(string name, int id);
        Task<bool> DeleteStudentByIdAsync(int id);

    }
}
