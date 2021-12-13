using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLSV.Data
{
    public class Lop
    {
        [Key]
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public virtual IEnumerable<ThongTinSinhVien> ThongTinSinhVien { get; set; }
    }
}
