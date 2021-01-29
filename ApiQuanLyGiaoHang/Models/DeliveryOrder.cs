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
        public DateTime? DateDeliveryOrder { get; set; }
        public string TheStatus { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TheUser IdStaffNavigation { get; set; }
        public virtual TheOrder IdTheOrderNavigation { get; set; }
    }
}
