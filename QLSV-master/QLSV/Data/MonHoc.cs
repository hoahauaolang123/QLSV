using System.ComponentModel.DataAnnotations;

namespace QLSV.Data
{
    public class MonHoc
    {
        [Key]
        public string MaMH { get; set; }
        public string TenMH { get; set; }
    }
}
