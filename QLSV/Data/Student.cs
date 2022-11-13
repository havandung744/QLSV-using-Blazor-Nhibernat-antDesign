namespace QLSV.Data
{
    public class Student
    {
        public virtual int Id { get; set; }
        public virtual string? Name { get; set; }
        public virtual int Sex { get; set; }
        public virtual int Age { get; set; }
        public virtual float Math { get; set; }
        public virtual float Literature { get; set; }
        public virtual float English { get; set; }
        public virtual float Medium { get; set; }
       
    }
}
