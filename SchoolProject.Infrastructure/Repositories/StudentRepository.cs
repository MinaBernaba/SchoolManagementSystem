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
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        private readonly ApplicationDbContext _context;
        public async Task<IEnumerable<Student>> GetAllStudentsAsync() =>await _context.Set<Student>().AsNoTracking().Include(x => x.Department).ToListAsync();
        public override async Task<Student> GetByIdAsync(int id) => await _context.Set<Student>().Include(x=> x.Department).SingleOrDefaultAsync( x => x.StudentId == id);
    }
}
