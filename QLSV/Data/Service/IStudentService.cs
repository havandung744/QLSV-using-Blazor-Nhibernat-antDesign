namespace QLSV.Data.Service
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
        Task<bool> AddOrUpdateStudent(Student student);
        Task<bool> DeleteStudentAsync(Student student);
        Task<Student> GetStudentByIdAsync(string id);
        Task<List<Student>> GetListStudentsBySearchAsync(string searchName);
        Task<int> GetTotalStudentByAcademicAbility(string academicAbility);
        Task<int> GetTotalStudentBySubjects(string subjectName, float min, float max);
        Task<bool> AddStudents(List<Student> students);

    }
}
