namespace SchoolProject.Data.Entities.DbTables
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal Salary { get; set; }
        public string? Image { get; set; }



        public virtual Department Department { get; set; }

        public virtual Department? DepartmentManager { get; set; }



        public virtual Instructor? Supervisor { get; set; }

        public virtual ICollection<Instructor> SupervisedInstructors { get; set; }

        public ICollection<InstructorSubject> InstructorSubjects { get; set; }
    }
}
