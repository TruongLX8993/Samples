namespace WebApplication.Domain.Entities.StudentAggregate
{
    public class Student
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
        // public List<StudentScore> StudentScores { get; set; }
    }
}