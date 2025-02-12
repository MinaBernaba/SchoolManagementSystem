namespace SchoolProject.Data.Entities.DbTables
{
    public class StudentSubject
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int? Grade { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }

    }
}
