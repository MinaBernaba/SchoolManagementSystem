using SchoolProject.Data.Entities.DbTables;
namespace SchoolProject.Service.Interfaces
{
    public interface IDepartmentService
    {
        Task<Department?> GetDepartmentByIdWithDetailsAsync(int id);
        Task<bool> IsDepartmentExistByIdAsync(int id);
    }
}
