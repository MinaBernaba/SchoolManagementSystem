using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.Interfaces;
using SchoolProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Services
{
    internal class StudentService(IStudentRepository studentRepository) : IStudentService
    {
        public async Task<List<Student>> GetAllStudentsAsync() => await studentRepository.GetAllStudentsAsync();
        public async Task<Student> GetStudentByIdAsync(int id) =>
            await studentRepository.GetAllNoTracking().Where(x => x.StudentId == id).Include(x => x.Department).FirstOrDefaultAsync();


        public async Task<string> AddAsync(Student student)
        {
            var studentResult = await studentRepository.GetAllNoTracking().Where(x => x.Name == student.Name).FirstOrDefaultAsync();

            if (studentResult != null)
                return "Exist";

            await studentRepository.AddAsync(student);
            return "Added";
        }
    }
}
