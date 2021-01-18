using System;
using System.Collections.Generic;

#nullable disable

namespace ApiQuanLyGiaoHang.Models
{
    public partial class DeliveryOrder
    {
        public int Id { get; set; }
        public int IdTheOrder { get; set; }
        public int? IdStaff { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DateDeliveryOrder { get; set; }
        public string TheStatus { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
