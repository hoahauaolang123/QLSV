using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSV.Data
{
    public class TKBGV
    {
       [Key]
        public int Id { get; set; }
        
        public string MaGV { get; set; }
        [ForeignKey("MaGV")]
        public GiaoVien GiaoVien { get; set; }
        public string MaLop { get; set; }
        [ForeignKey("MaLop")]
        public Lop Lop { get; set; }
        public string MaMH { get; set; }
        [ForeignKey("MaMH")]
        public MonHoc MonHoc { get; set; }
        public string TenGV { get; set; }
        public string TenLop { get; set; }
        public string TenMH { get; set; }
        public DateTime? TimeDay { get; set; }
    }
}
