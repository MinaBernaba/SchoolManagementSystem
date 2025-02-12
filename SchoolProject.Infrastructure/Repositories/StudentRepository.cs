using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.DbTables;
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
        #region ctor And Field
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        #endregion
        public async Task<List<Student>> GetAllStudentsAsync() => await _context.Set<Student>().AsNoTracking().Include(x => x.Department).ToListAsync();
    }
}
