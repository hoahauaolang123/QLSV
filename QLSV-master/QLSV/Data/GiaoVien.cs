using System.ComponentModel.DataAnnotations;

namespace QLSV.Data
{
    public class GiaoVien
    {
        [Key]
        public string MaGV { get; set; }
        public string TenGV { get; set; }
    }
}
