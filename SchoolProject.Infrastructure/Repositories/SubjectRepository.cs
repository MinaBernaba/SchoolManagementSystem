using SchoolProject.Data.Entities.DbTables;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.Interfaces;

namespace SchoolProject.Infrastructure.Repositories
{
    public class SubjectRepository : GenericRepositoryAsync<Subject>, ISubjectRepository
    {
        public SubjectRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
