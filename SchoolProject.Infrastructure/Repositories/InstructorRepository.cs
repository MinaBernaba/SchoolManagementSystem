using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.Interfaces;

namespace SchoolProject.Infrastructure.Repositories
{
    internal class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
    {
        public InstructorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
