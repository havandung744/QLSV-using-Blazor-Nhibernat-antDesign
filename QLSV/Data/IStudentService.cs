namespace QLSV.Data
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
    }
}
