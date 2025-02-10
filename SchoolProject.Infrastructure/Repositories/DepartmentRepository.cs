using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.Interfaces;

namespace SchoolProject.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        #region field and ctor 
        ApplicationDbContext context;
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        #endregion

        public async Task<bool> IsDepartmentExistByIdAsync(int id) => await context.Set<Department>().AnyAsync(x => x.DepartmentId.Equals(id));
    }
}
