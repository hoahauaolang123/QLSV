using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace QLSV.Data
{
    public class QLSVDBContext :DbContext
    {
        public QLSVDBContext(DbContextOptions<QLSVDBContext>options):base(options)
        {
           
        }
        public  DbSet<GiaoVien> GiaoVien { get; set; }
        public  DbSet<MonHoc> MonHoc { get; set; }
        public DbSet<Lop> Lop { get; set; }
        public DbSet<SinhVien> SinhVien { get; set; }
        public  DbSet<ThongTinSinhVien> ThongTinSinhVien { get; set; }
        public DbSet<TKBGV> TKBGV { get; set; }
   




    }
}
