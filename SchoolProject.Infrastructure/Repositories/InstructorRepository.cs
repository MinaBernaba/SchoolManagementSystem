using SchoolProject.Data.Entities.DbTables;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.Interfaces;

namespace SchoolProject.Infrastructure.Repositories
{
    public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
    {
        public InstructorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
