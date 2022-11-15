using FluentNHibernate.Mapping;

namespace QLSV.Data
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("Id");
            Map(x => x.Name).Column("Name");
            Map(x => x.Sex).Column("Sex");
            Map(x => x.Age).Column("Age");
            Map(x => x.Math).Column("Math");
            Map(x => x.Literature).Column("Literature");
            Map(x => x.English).Column("English");
            Map(x => x.Medium).Column("Medium");
            Map(x => x.AcademicAbility).Column("AcademicAbility");
            Table("Student");
        }
    }
}
