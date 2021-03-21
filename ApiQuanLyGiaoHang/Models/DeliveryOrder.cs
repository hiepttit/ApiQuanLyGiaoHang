using System;
using System.Collections.Generic;

#nullable disable

namespace ApiQuanLyGiaoHang.Models
{
    public partial class DeliveryOrder
    {
        public string Id { get; set; }
        public string IdTheOrder { get; set; }
        public string IdStaff { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public double? Coefficient { get; set; }
        public int? TheStatus { get; set; }
        public DateTime? DeletedAt { get; set; }
        public double? Amount { get; set; }

        public virtual TheUser IdStaffNavigation { get; set; }
        public virtual TheOrder IdTheOrderNavigation { get; set; }
    }
}
