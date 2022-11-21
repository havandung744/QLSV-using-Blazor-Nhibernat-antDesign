using BlazorInputFile;
using Microsoft.AspNetCore.Components;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using QLSV.Data;

namespace QLSV.Pages
{
    public partial class Excel : ComponentBase
    {
        StudentService studentService = new StudentService();
        public async Task CreateDocument()
        {
            IWorkbook workBook = new HSSFWorkbook();
            //var dataFormat = workBook.CreateDataFormat();
            //var dataStyle = workBook.CreateCellStyle();
            //dataStyle.DataFormat = dataFormat.GetFormat("MM/dd//yyyy HH:mm:ss");
            ISheet workSheet = workBook.CreateSheet("Sheet1");
            workSheet.SetColumnWidth(1, 25 * 256);
            List<Student> listStudents = await studentService.GetAllStudents();

            // tạo style
            ICellStyle style = workBook.CreateCellStyle();
            //Set border style
            style.BorderBottom = BorderStyle.Double;
            style.BottomBorderColor = HSSFColor.Yellow.Index;
            //Set font style
            IFont font = workBook.CreateFont();
            font.Color = HSSFColor.White.Index;
            font.FontName = "Arial";
            font.FontHeight = 500;
            font.IsItalic = true;
            style.Alignment = HorizontalAlignment.Center;
            style.SetFont(font);
            //Set background color
            style.FillBackgroundColor = IndexedColors.Green.Index;
            style.FillPattern = FillPattern.SolidForeground;
            //Tạo row
            var row0 = workSheet.CreateRow(0);
            //Merge lại row đầu 3 cột
            row0.CreateCell(0); // tạo ra cell trc khi merge
            CellRangeAddress cellMerge = new CellRangeAddress(0, 0, 0, 8);
            workSheet.AddMergedRegion(cellMerge);
            row0.GetCell(0).SetCellValue("Thông tin sinh viên");
            row0.GetCell(0).CellStyle = style;
            //Ghi tên cột ở row 1
            var row1 = workSheet.CreateRow(1);
            row1.CreateCell(0).SetCellValue("ID");
            row1.CreateCell(1).SetCellValue("Tên");
            row1.CreateCell(2).SetCellValue("Giới tính");
            row1.CreateCell(3).SetCellValue("Tuổi");
            row1.CreateCell(4).SetCellValue("Điểm toán");
            row1.CreateCell(5).SetCellValue("Điểm văn");
            row1.CreateCell(6).SetCellValue("Điểm anh");
            row1.CreateCell(7).SetCellValue("Điểm TB");
            row1.CreateCell(8).SetCellValue("Học lực");
            //bắt đầu duyệt mảng và ghi tiếp tục
            int rowIndex = 2;
            foreach (var item in listStudents)
            {
                //tao row mới
                var newRow = workSheet.CreateRow(rowIndex);

                //set giá trị
                newRow.CreateCell(0).SetCellValue(item.Id);
                newRow.CreateCell(1).SetCellValue(item.Name);
                newRow.CreateCell(2).SetCellValue(item.Sex);
                newRow.CreateCell(3).SetCellValue(item.Age);
                newRow.CreateCell(4).SetCellValue(item.Math);
                newRow.CreateCell(5).SetCellValue(item.Literature);
                newRow.CreateCell(6).SetCellValue(item.English);
                newRow.CreateCell(7).SetCellValue(item.Medium);
                newRow.CreateCell(8).SetCellValue(item.AcademicAbility);

                //tăng index
                rowIndex++;
            }

            MemoryStream ms = new MemoryStream();
            workBook.Write(ms, false);
            byte[] bytes = ms.ToArray();
            ms.Close();

            await jsruntime.SaveAsFileAsync("StudentList", bytes, "application/vnd.ms-excel");


        }

        IFileListEntry file;
        public async Task LoadFile(IFileListEntry[] files)
        {
            file = files.FirstOrDefault();
            if (file != null)
            {
                //await fileUpload.UploadAsync(file);
            }

        }

    }
}
