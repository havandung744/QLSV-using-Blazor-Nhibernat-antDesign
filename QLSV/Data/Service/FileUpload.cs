using BlazorInputFile;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace QLSV.Data.Service
{
    public class FileUpload : IFileUpload
    {
        private readonly IStudentService _studentService;
        private readonly IWebHostEnvironment _environment;
        public FileUpload(IStudentService studentService, IWebHostEnvironment webHostEnvironment)
        {
            _studentService = studentService;
            _environment = webHostEnvironment;
        }
        string path;
        List<Student> students = new List<Student>();
        public async Task InputFile()
        {
            IWorkbook workbook = null;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            if (path.IndexOf(".xlsx") > 0)
            {
                workbook = new XSSFWorkbook(fs);
            }
            else if (path.IndexOf(".xls") > 0)
            {
                workbook = new HSSFWorkbook(fs);
            }

            ISheet sheet = workbook.GetSheetAt(0);
            if (sheet != null)
            {
                int rowCount = sheet.LastRowNum;    
                for (int i = 2; i <= rowCount; i++)
                {
                    Student student = new Student();
                    IRow curRow = sheet.GetRow(i);
                    student.Name = curRow.GetCell(1).StringCellValue.Trim();
                    student.Sex = (int)curRow.GetCell(2).NumericCellValue;
                    student.Age = (int)curRow.GetCell(3).NumericCellValue;
                    student.Math = (float)curRow.GetCell(4).NumericCellValue;
                    student.Literature = (float)curRow.GetCell(5).NumericCellValue;
                    student.English = (float)curRow.GetCell(6).NumericCellValue;
                    student.Medium = 10;
                    student.AcademicAbility = "Giỏi";
                    students.Add(student);
                    _studentService.AddOrUpdateStudent(student);
                    //_studentService.AddStudents(students);
                }

            }
            //File.Delete(Path.Combine(path));
        }

        public async Task UploadAsync(IFileListEntry file)
        {
            try
            {
                path = Path.Combine(_environment.ContentRootPath, "Upload", file.Name);
                var ms = new MemoryStream();
                await file.Data.CopyToAsync(ms);
                using (FileStream file1 = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    ms.WriteTo(file1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
