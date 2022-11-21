using NHibernate;
using NHibernate.Linq;
using QLSV.Data.Service;
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
            Student student;
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        student = await session.GetAsync<Student>(id);
                        return student;
                    }
                    catch (Exception ex)
                    {
                        //await transaction.RollbackAsync();
                        throw ex;
                    }
                }
            }
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

        public async Task<bool> DeleteStudentAsync(Student student)
        {
            bool result = false;
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {

                        await session.DeleteAsync(student);
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

        public async Task<List<Student>> GetListStudentsBySearchAsync(string searchName)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        List<Student> students;
                        students = session.Query<Student>().Where(c => c.Name.Like('%' + searchName + '%')).ToList();
                        //await transaction.CommitAsync();
                        return students;
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        throw ex;
                    }
                }
            }
        }

        public async Task<int> GetTotalStudentByAcademicAbility(string academicAbility)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                try
                {
                    int total = session.Query<Student>().Where(c => c.AcademicAbility == academicAbility).Count();
                    return total;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public async Task<int> GetTotalStudentBySubjects(string subjectName, float min, float max)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                try
                {
                    int total = 0;
                    if (subjectName == "Math")
                    {
                        total = session.Query<Student>().Where(c => c.Math >= min && c.Math < max).Count();
                    }
                    else if (subjectName == "English")
                    {
                        total = session.Query<Student>().Where(c => c.English >= min && c.English < max).Count();
                    }
                    else if (subjectName == "Literature")
                    {
                        total = session.Query<Student>().Where(c => c.Literature >= min && c.Literature < max).Count();
                    }
                    return total;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public async Task<bool> AddStudents(List<Student> students)
        {
            bool result = false;
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        foreach(var student in students)
                        {
                            student.Id = Guid.NewGuid().ToString();
                            session.Save(student);
                        }
                        transaction.Commit();
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