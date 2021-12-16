using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSV.Data
{
    public class SinhVien
    {
        [Key]
        public string MaSV { get; set; }
        public string TenSV { get; set; }
        public string MaLop { get; set; }
        [ForeignKey("MaLop")]
        public Lop Lop { get; set; }
        public string TenLop { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string Diachi { get; set; }
     
    }
}
