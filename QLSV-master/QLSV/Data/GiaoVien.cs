using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace QLSV.Data
{
    public class GiaoVien
    {
        [Key]
        public string MaGV { get; set; }
        public string TenGV { get; set; }
        public IEnumerable<TKBGV> TKBGV { get; set; }
    }
}
