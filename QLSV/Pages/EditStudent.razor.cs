using Microsoft.AspNetCore.Components;
using QLSV.Data;
namespace QLSV.Pages
{
    public partial class EditStudent : ComponentBase
    {
        [Parameter] public EventCallback Cancel { get; set; }
        [Parameter] public EventCallback ValueChange { get; set; }
        StudentEditModel EditModel { get; set; } = new StudentEditModel();
        List<Sex> sexs;   

        public class Sex
        {
            public string Name { get; set; }
        }

        protected override void OnInitialized()
        {
            sexs = new List<Sex>
            {
                new Sex{Name = "Nam"},
                new Sex{Name = "Nữ"}
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
        }

    }
}
