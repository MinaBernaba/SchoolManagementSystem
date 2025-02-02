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
        public async Task<IEnumerable<Student>> GetAllStudentsAsync() => await studentRepository.GetAllStudentsAsync();

        public async Task<Student> GetStudentByIdAsync(int id) => await studentRepository.GetByIdAsync(id);
    }
}
