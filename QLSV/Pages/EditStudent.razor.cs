using Microsoft.AspNetCore.Components;
using QLSV.Data;
namespace QLSV.Pages
{
    public partial class EditStudent : ComponentBase
    {
        [Parameter] public EventCallback Cancel { get; set; }
        [Parameter] public EventCallback<Student> ValueChange { get; set; }
        StudentEditModel EditModel { get; set; } = new StudentEditModel();
        List<Sex> sexs;   

        public class Sex
        {
            public int value { get; set; }
            public string Name { get; set; }
        }

        protected override void OnInitialized()
        {
            sexs = new List<Sex>
            {
                new Sex{value=0, Name = "Nam"},
                new Sex{value=1,Name = "Nữ"}
            };
        }

        public void LoadData(Student student)
        {
            EditModel.id = student.Id;
            EditModel.ten = student.Name;
            EditModel.gioitinh = student.Sex;
            EditModel.tuoi = student.Age;
            EditModel.diemtoan = student.Math;
            EditModel.diemvan = student.Literature;
            EditModel.diemanh = student.English;
            EditModel.diemtb = student.Medium;
            StateHasChanged();
        }

        public void UpdateStudent()
        {
            Student student = new Student();
            student.Id = EditModel.id;
            student.Name = EditModel.ten;
            student.Sex = EditModel.gioitinh;
            student.Age = EditModel.tuoi;
            student.Math = EditModel.diemtoan;
            student.Literature = EditModel.diemvan;
            student.English = EditModel.diemanh;
            student.Medium = (float)Math.Round(((EditModel.diemtoan + EditModel.diemvan + EditModel.diemanh) / 3), 2);
            student.AcademicAbility = student.Medium >= 8 ? "Giỏi" : (student.Medium >= 6.5 ? "Khá" : (student.Medium >= 5 ? "Trung bình" : "Yếu"));
            //Thực hiện update sinh viên
            ValueChange.InvokeAsync(student);
        }

    }
}
