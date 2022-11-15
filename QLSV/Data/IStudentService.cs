namespace QLSV.Data
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();

        Task<bool> AddStudent(Student student); 

        Task<bool> UpdateStudent(Student student);

        Task<bool> AddOrUpdateStudent(Student student); 
    }
}
