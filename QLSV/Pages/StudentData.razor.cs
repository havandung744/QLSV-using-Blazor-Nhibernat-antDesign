using Microsoft.AspNetCore.Components;
using QLSV.Data;

namespace QLSV.Pages
{
    public partial class StudentData : ComponentBase
    {
        [Inject] IStudentService studentService { get; set; }
        List<Student> students { get; set; }
        List<StudentViewModel> studentsViewModels { get; set; }
        EditStudent editStudent { get; set; }
        bool visible = false;
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
                models.Add(model);
                stt++;
            });
            return models;
        }

        void AddStudent()
        {
            var studentData = new Student();
            //ShowStudentDetail(studentData);

        }

        void ShowStudentDetail(Student data)
        {
            editStudent.LoadData(data);
            visible = true;
        }


    }

}
