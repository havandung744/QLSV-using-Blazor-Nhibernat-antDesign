using Microsoft.AspNetCore.Components;
using QLSV.Data;

namespace QLSV.Pages
{
    public partial class StudentData : ComponentBase
    {
        [Inject] IStudentService studentService { get; set; }
        List<Student> students { get; set; }
        List<StudentViewModel> studentsViewModels { get; set; }
        EditStudent editStudent = new EditStudent();
        TaskSearchStudent taskSearchStudents = new TaskSearchStudent();
        bool visible = false;
        int stt=1;
        protected override async Task OnInitializedAsync()
        {
            studentsViewModels = new();
            students = new();
            await LoadAsync();
        }
        public async Task LoadAsync()
        {
            studentsViewModels.Clear();
            students = await studentService.GetAllStudents();
            studentsViewModels = GetViewModels(students);
            StateHasChanged();
        }
        List<StudentViewModel> GetViewModels(List<Student> datas)
        {
            var models = new List<StudentViewModel>();
            StudentViewModel model;

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
            var resultAdd = await studentService.AddOrUpdateStudent(data);
            await LoadAsync();
            visible = false;
        }

        async Task Edit(StudentViewModel studentViewModel)
        {
            //var studentData = students.FirstOrDefault(c => c.Id == studentViewModel.id);
            Student student = await studentService.GetStudentByIdAsync(studentViewModel.id);
            ShowStudentDetail(student);
        }

        async Task DeleteStudent(StudentViewModel studentViewModel)
        {
            Student studen = await studentService.GetStudentByIdAsync(studentViewModel.id);
            await studentService.DeleteStudentAsync(studen);
            await LoadAsync();
        }

        public class TaskSearchStudent
        {
            public string Name { get; set; }
        }

        async Task Search()
        {
            var name = taskSearchStudents.Name;
            studentsViewModels.Clear();
            students = await studentService.GetListStudentsBySearchAsync(name);
            studentsViewModels = GetViewModels(students);
            StateHasChanged();

        }

    }

}
