using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Interfaces;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Service.Services
{
    internal class StudentService(IStudentRepository studentRepository) : IStudentService
    {
        public async Task<List<Student>> GetAllStudentsAsync() => await studentRepository.GetAllStudentsAsync();
        public async Task<Student> GetStudentByIdAsync(int id) =>
            await studentRepository.GetAllNoTracking().Where(x => x.StudentId == id).Include(x => x.Department).FirstOrDefaultAsync();
        public async Task AddAsync(Student student) => await studentRepository.AddAsync(student);
        public async Task<bool> IsStudentNameExistAsync(string name) => await studentRepository.GetAllNoTracking().AnyAsync(x => x.Name == name);
        public async Task<bool> IsStudentIdExistAsync(int id) => await studentRepository.GetAllNoTracking().AnyAsync(x => x.StudentId == id);
        public async Task UpdateStudentAsync(Student student) => await studentRepository.UpdateAsync(student);
        public async Task<bool> IsStudentNameExistExceptSelf(string name, int id) =>
            await studentRepository.GetAllNoTracking().AnyAsync(x => x.Name.Equals(name) && !x.StudentId.Equals(id));
    }
}