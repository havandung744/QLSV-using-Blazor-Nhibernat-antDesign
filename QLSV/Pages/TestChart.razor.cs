using AntDesign.Charts;
using Microsoft.AspNetCore.Components;
using QLSV.Data;
namespace QLSV.Pages
{
    public partial class TestChart : ComponentBase
    {
        object[] data3 = new object[1000];
        protected override async Task OnInitializedAsync()
        {
            StudentService studentService = new StudentService();
            var good = studentService.GetTotalStudentByAcademicAbility("Giỏi");
            var rather = studentService.GetTotalStudentByAcademicAbility("Khá");
            var medium = studentService.GetTotalStudentByAcademicAbility("Trung bình");
            var feebleness = studentService.GetTotalStudentByAcademicAbility("Yếu");
            object[] data2 =
        {
        new
        {
            type = "Giỏi",
            sales = good.Result
        },
        new
        {
            type = "Khá",
            sales = rather.Result
        },
        new
        {
            type = "Trung bình",
            sales = medium.Result
        },
        new
        {
            type = "Yếu",
            sales = feebleness.Result
        },
    };
            data3 = data2;
            await base.OnInitializedAsync();
        }

        #region 示例2

        ColumnConfig config2 = new ColumnConfig
        {
            //Title = new Title
            //{
            //    Visible = true,
            //    Text = "基础柱状图-图形标签"
            //},
            //Description = new Description
            //{
            //    Visible = true,
            //    Text = "基础柱状图图形标签默认位置在柱形上部。",
            //},
            ForceFit = true,
            Padding = "auto",
            XField = "type",
            YField = "sales",
            Meta = new
            {
                Type = new
                {
                    Alias = "Xếp hạng học lực"
                },
                Sales = new
                {
                    Alias = "Số lượng"
                }
            },
            Label = new ColumnViewConfigLabel
            {
                Visible = true,
                Style = new TextStyle
                {
                    FontSize = 12,
                    FontWeight = 600,
                    Opacity = 0.6,
                }

            }
        };

        #endregion 示例2
    }
}
