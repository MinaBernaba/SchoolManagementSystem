using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Repositories
{
    public class StudentRepository(ApplicationDbContext context) : IStudentRepository
    {

        public async Task<List<Student>> GetAllAsync() => await context.Students.Include(x => x.Department).ToListAsync();
        public async Task<Student> GetByIdAsync(int id) => await context.Students.Include(x=> x.Department).SingleOrDefaultAsync( x => x.StudentId == id);
        

    }
}
