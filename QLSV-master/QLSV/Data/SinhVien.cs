using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace QLSV.Data
{
    public class SinhVien
    {
        [Key]
        public string MaSV { get; set; }
        public string TenSV { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public string Diachi { get; set; }
        public virtual IEnumerable<ThongTinSinhVien> ThongTinSinhVien{get; set;}
    }
}
