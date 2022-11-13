using NHibernate;
using ISession = NHibernate.ISession;

namespace QLSV.Data
{
    public class StudentService : IStudentService
    {
        public async Task<List<Student>> GetAllStudents()
        {
            try
            {
                List<Student> students;
                using (ISession session = FluentNHibernateHelper.OpenSession())
                {
                    students = session.Query<Student>().ToList();
                }
                return students;
            }
            catch(Exception e){
                throw e;
            }
        }
    }
}