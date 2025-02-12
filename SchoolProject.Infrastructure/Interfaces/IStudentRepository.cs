using SchoolProject.Data.Entities.DbTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Interfaces
{
    public interface IStudentRepository : IGenericRepositoryAsync<Student>
    {
        Task<List<Student>> GetAllStudentsAsync();
    }
}
