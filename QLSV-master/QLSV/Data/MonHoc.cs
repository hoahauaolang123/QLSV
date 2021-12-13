﻿using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace QLSV.Data
{
    public class MonHoc
    {
        [Key]
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public IEnumerable<TKBGV>TKBGV  { get; set; }
    }
}
