using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Interfaces;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Service.Services
{
    public class DepartmentService(IDepartmentRepository departmentRepo) : IDepartmentService
    {
        #region Handle Department query with its details

        public async Task<Department?> GetDepartmentByIdWithDetailsAsync(int id)
            => await departmentRepo.GetAllNoTracking()
            .Where(x => x.DepartmentId.Equals(id))
            //.Include(x => x.Students)
            .Include(x => x.Instructors)
            .Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subject)
            .Include(x => x.InstructorManager)
            .FirstOrDefaultAsync();
        #endregion

        public async Task<bool> IsDepartmentExistByIdAsync(int id) => await departmentRepo.IsDepartmentExistByIdAsync(id);
    }
}
