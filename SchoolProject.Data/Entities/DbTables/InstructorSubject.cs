namespace SchoolProject.Data.Entities.DbTables
{
    public class InstructorSubject
    {
        public int InstructorSubjectId { get; set; }

        public int SubjectId { get; set; }

        public int instructorId { get; set; }

        public virtual Instructor instructor { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
