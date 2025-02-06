using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task AddAsync(Student student);
        Task<bool> IsStudentNameExistAsync(string name);
        Task<bool> IsStudentIdExistAsync(int id);
        Task UpdateStudentAsync(Student student);
        Task<bool> IsStudentNameExistExceptSelf(string name, int id);
    }
}
