using SchoolProject.Data.Entities.DbTables;

namespace SchoolProject.Infrastructure.Interfaces
{
    public interface IDepartmentRepository : IGenericRepositoryAsync<Department>
    {
        Task<bool> IsDepartmentExistByIdAsync(int id);
    }
}
