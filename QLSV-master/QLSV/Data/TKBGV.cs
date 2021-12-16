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
        public string MaLop { get; set; }
  
        public string MaMH { get; set; }
        public DateTime? TimeDay { get; set; }
      
        [ForeignKey("MaGV")]
        public GiaoVien GiaoVien { get; set; }
        [ForeignKey("MaLop")]
        public Lop Lop { get; set; }
  
    
        [ForeignKey("MaMH")]
        public MonHoc MonHoc { get; set; }
    }
}
