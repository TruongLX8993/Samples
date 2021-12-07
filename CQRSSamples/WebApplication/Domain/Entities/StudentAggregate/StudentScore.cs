namespace WebApplication.Domain.Entities.StudentAggregate
{
    public class StudentScore
    {
        public int StudentId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectId { get; set; }
        public string ClassName { get; set; }
        public string ClassId { get; set; }
        public decimal Score { get; set; }
    }
}