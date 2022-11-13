using System.ComponentModel.DataAnnotations;

namespace QLSV.Data
{
    public class StudentViewModel
    {
        public int id;
        [Display(Name = "No.")]
        public int stt { get; set; }

        [Display(Name = "Tên sinh viên")]
        public string ten { get; set; }

        [Display(Name = "Giới tính")]
        public int gioitinh { get; set; }

        [Display(Name = "Tuổi")]
        public int tuoi { get; set; }
        [Display(Name = "Điểm toán")]
        public float diemtoan { get; set; }
        [Display(Name = "Điểm văn")]
        public float diemvan { get; set; }
        [Display(Name = "Điểm Anh")]
        public float diemanh { get; set; }

        [Display(Name = "Điểm trung bình")]
        public float diemtb { get; set; }
    }
}
