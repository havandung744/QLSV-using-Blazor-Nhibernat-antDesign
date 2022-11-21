using AntDesign.Charts;
using Microsoft.AspNetCore.Components;
using QLSV.Data;
namespace QLSV.Pages
{
    public partial class TestChart : ComponentBase
    {
        object[] data1 = new object[9999];
        object[] data2 = new object[9999];
        object[] data3 = new object[9999];
        object[] data4 = new object[9999];
        protected override async Task OnInitializedAsync()
        {
            StudentService studentService = new StudentService();
            var good =  await studentService.GetTotalStudentByAcademicAbility("Giỏi");
            var rather = await studentService.GetTotalStudentByAcademicAbility("Khá");
            var medium = await studentService.GetTotalStudentByAcademicAbility("Trung bình");
            var feebleness = await studentService.GetTotalStudentByAcademicAbility("Yếu");
            // môn toán
            var mathGood = await studentService.GetTotalStudentBySubjects("Math", 8, 11);
            var mathRather = await studentService.GetTotalStudentBySubjects("Math", (float)6.5, 8);
            var mathMedium = await studentService.GetTotalStudentBySubjects("Math", 5, (float)6.5);
            var mathweakness = await studentService.GetTotalStudentBySubjects("Math", 0, 5);
            // môn văn
            var LiteratureGood = await studentService.GetTotalStudentBySubjects("Literature", 8, 11);
            var LiteratureRather = await studentService.GetTotalStudentBySubjects("Literature", (float)6.5, 8);
            var LiteratureMedium = await studentService.GetTotalStudentBySubjects("Literature", 5, (float)6.5);
            var Literatureweakness = await studentService.GetTotalStudentBySubjects("Literature", 0, 5);
            // môn anh
            var EnglishGood = await studentService.GetTotalStudentBySubjects("English", 8, 11);
            var EnglishRather = await studentService.GetTotalStudentBySubjects("English", (float)6.5, 8);
            var EnglishMedium = await studentService.GetTotalStudentBySubjects("English", 5, (float)6.5);
            var Englishweakness = await studentService.GetTotalStudentBySubjects("English", 0, 5);
            object[] data01 =
                {
                    new
                    {
                        type = "Giỏi",
                        sales = good
                    },
                    new
                    {
                        type = "Khá",
                        sales = rather
                    },
                    new
                    {
                        type = "Trung bình",
                        sales = medium
                    },
                    new
                    {
                        type = "Yếu",
                        sales = feebleness
                    },
                  };
            data1 = data01;

            object[] data02 =
                {
                    new
                    {
                        type = "Giỏi",
                        sales = mathGood
                    },
                    new
                    {
                        type = "Khá",
                        sales = mathRather
                    },
                    new
                    {
                        type = "Trung bình",
                        sales = mathMedium
                    },
                    new
                    {
                        type = "Yếu",
                        sales = mathweakness
                    },
                  };
            data2 = data02;
            object[] data03 =
                {
                    new
                    {
                        type = "Giỏi",
                        sales = LiteratureGood
                    },
                    new
                    {
                        type = "Khá",
                        sales = LiteratureRather
                    },
                    new
                    {
                        type = "Trung bình",
                        sales = LiteratureMedium
                    },
                    new
                    {
                        type = "Yếu",
                        sales = Literatureweakness
                    },
                  };
            data3 = data03;
            object[] data04 =
                {
                    new
                    {
                        type = "Giỏi",
                        sales = EnglishGood
                    },
                    new
                    {
                        type = "Khá",
                        sales = EnglishRather
                    },
                    new
                    {
                        type = "Trung bình",
                        sales = EnglishMedium
                    },
                    new
                    {
                        type = "Yếu",
                        sales = Englishweakness
                    },
                  };
            data4 = data04;
            //await base.OnInitializedAsync();
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
