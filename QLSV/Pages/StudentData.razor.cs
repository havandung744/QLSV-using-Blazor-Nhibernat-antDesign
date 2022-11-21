using BlazorInputFile;
using Microsoft.AspNetCore.Components;
using QLSV.Data;
using QLSV.Data.Service;

namespace QLSV.Pages
{
    public partial class StudentData : ComponentBase
    {
        [Inject] IStudentService StudentService { get; set; }
        List<Student> students { get; set; }
        List<StudentViewModel> studentsViewModels { get; set; }
        EditStudent editStudent = new EditStudent();
        TaskSearchStudent taskSearchStudents = new TaskSearchStudent();
        bool visible = false;
        bool loading;

        protected override async Task OnInitializedAsync()
        {
            studentsViewModels = new();
            students = new();
            await LoadAsync();
        }

        public async Task LoadAsync()
        {
            loading = true;
            studentsViewModels.Clear();
            //await Task.Delay(3000);
            students = await StudentService.GetAllStudents();
            studentsViewModels = GetViewModels(students);
            loading = false;
            StateHasChanged();
        }

        List<StudentViewModel> GetViewModels(List<Student> datas)
        {
            var models = new List<StudentViewModel>();
            StudentViewModel model;
            int stt = 1;
            datas.ForEach(c =>
            {
                model = new StudentViewModel();
                model.stt = stt;
                model.ten = c.Name;
                model.gioitinh = c.Sex;
                model.tuoi = c.Age;
                model.diemtoan = c.Math;
                model.diemanh = c.English;
                model.diemvan = c.Literature;
                model.diemtb = c.Medium;
                model.id = c.Id;
                model.hocluc = c.AcademicAbility;

                models.Add(model);
                stt++;
            });
            return models;
        }

        void AddStudent()
        {
            var studentData = new Student();
            ShowStudentDetail(studentData);
        }

        void ShowStudentDetail(Student data)
        {
            editStudent.LoadData(data);
            visible = true;
        }

        async Task Save(Student data)
        {
            var resultAdd = await StudentService.AddOrUpdateStudent(data);
            await LoadAsync();
            visible = false;
        }

        async Task Edit(StudentViewModel studentViewModel)
        {
            //var studentData = students.FirstOrDefault(c => c.Id == studentViewModel.id);
            Student student = await StudentService.GetStudentByIdAsync(studentViewModel.id);
            ShowStudentDetail(student);
        }

        async Task DeleteStudent(StudentViewModel studentViewModel)
        {
            Student studen = await StudentService.GetStudentByIdAsync(studentViewModel.id);
            await StudentService.DeleteStudentAsync(studen);
            await LoadAsync();
        }

        public class TaskSearchStudent
        {
            public string? Name { get; set; }
        }

        async Task Search()
        {
            var name = taskSearchStudents.Name;
            studentsViewModels.Clear();
            students = await StudentService.GetListStudentsBySearchAsync(name);
            studentsViewModels = GetViewModels(students);
            StateHasChanged();
        }

        IFileListEntry file;
        public async Task LoadFile(IFileListEntry[] files)
        {
            file = files.FirstOrDefault();
            if (file != null)
            {
                await fileUpload.UploadAsync(file);
            }
        }
        public async Task InputFile()
        {
            await fileUpload.InputFile();
            file = null;
            await LoadAsync();
        }
    }

}
