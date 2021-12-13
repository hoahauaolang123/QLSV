using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSV.Data
{
    public class ThongTinSinhVien
    {
        [Key]
        public int Id { get; set; }
        public string MaSV { get; set; }
        [ForeignKey("MaSV")]
        public SinhVien SinhVien { get; set; }
        public string TenSV { get; set; }
        public string MaLop { get; set; }
        [ForeignKey("MaLop")]
        public Lop Lop { get; set; }
        public string TenLop { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public string Diachi { get; set; }
        
    }
}
