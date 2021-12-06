using FluentNHibernate.Mapping;
using WebApplication.Domain.Entities.StudentAggregate;

namespace WebApplication.Infrastructures.Data.NhibernateRepository.Mapper
{
    public class StudentMapper : ClassMap<Student>
    {
        public StudentMapper()
        {
            Id(student => student.Id);
            Map(student => student.Name);
        }
    }
}