using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Interfaces
{
    public interface IDepartmentRepository : IGenericRepositoryAsync<Department>
    {
        Task<bool> IsDepartmentExistByIdAsync(int id);
    }
}
