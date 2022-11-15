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
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Student> GetStudentByIdAsync(string id)
        {
            {
                Student st = new Student();
                List<Student> students;
                try
                {
                    using (ISession session = FluentNHibernateHelper.OpenSession())
                    {
                        students = session.Query<Student>().ToList();
                    }
                    if (students != null)
                    {
                        st = students.Where(c => c.Id == id).FirstOrDefault();
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                return st;
            }
        }
        public async Task<bool> AddStudent(Student student)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(student);

                        tran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                        return false;
                    }
                }
            }
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            bool result = false;
            //if (student.Id == null)
            //{
            //    //insert 
            //    //new guid
            //}
            //else
            //{
            //    //update
            //}

            //Student st = GetStudentByIdAsync(student.Id);
            //st.Sex = student.Sex;
            //st.Literature = student.Literature;
            //st.English = student.English;
            // to go
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(student);
                        await transaction.CommitAsync();
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        throw ex;
                    }
                }
            }
            return result;
        }

        public async Task<bool> AddOrUpdateStudent(Student student)
        {
            bool result = false;
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        if (string.IsNullOrEmpty(student.Id))
                        {
                            student.Id = Guid.NewGuid().ToString();
                           await session.SaveAsync(student);
                        }
                        else
                        {
                            await session.UpdateAsync(student);
                        }
                        await transaction.CommitAsync();
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        throw ex;
                    }
                }
            }
            return result;
        }



    }
}