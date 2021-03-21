using System;
using System.Collections.Generic;

#nullable disable

namespace ApiQuanLyGiaoHang.Models
{
    public partial class BasicSalary
    {
        public int Id { get; set; }
        public int? Salary { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
