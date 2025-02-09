using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasOne(x => x.InstructorManager).WithOne(x => x.DepartmentManager).HasForeignKey<Department>(x => x.InstructorManagerId).OnDelete(DeleteBehavior.Restrict); ;
            modelBuilder.Entity<Instructor>().HasOne(x => x.Department).WithMany(x => x.Instructors).HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Restrict); ;
            modelBuilder.Entity<Instructor>().HasOne(x => x.Supervisor).WithMany(x => x.SupervisedInstructors).HasForeignKey(x => x.SupervisorId).OnDelete(DeleteBehavior.Restrict); ;

        }
        #region DbSets
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<InstructorSubject> InstructorSubjects { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        #endregion

    }
}
