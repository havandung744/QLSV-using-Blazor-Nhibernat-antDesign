using System.ComponentModel.DataAnnotations;

namespace QLSV.Data
{
    public class StudentEditModel
    {
        public string id { get; set; }
        //public int stt { get; set; }

        public string ten { get; set; }

        public int gioitinh { get; set; }

        public int tuoi { get; set; }
        public float diemtoan { get; set; }
        public float diemvan { get; set; }
        public float diemanh { get; set; }

        public float diemtb { get; set; }

    }
}
