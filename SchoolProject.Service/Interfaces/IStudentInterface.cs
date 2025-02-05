using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task AddAsync(Student student);
        Task<bool> IsStudentNameExist(string name);
    }
}
