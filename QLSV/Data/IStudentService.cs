namespace QLSV.Data
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
        Task<bool> AddOrUpdateStudent(Student student);
        Task<bool> DeleteStudentAsync(Student student);
        Task<Student> GetStudentByIdAsync(string id);
        Task<List<Student>> GetListStudentsBySearchAsync(string searchName);
        Task<int> GetTotalStudentByAcademicAbility(string academicAbility);
    }
}
