using System;
using System.Collections.Generic;

#nullable disable

namespace ApiQuanLyGiaoHang.Models
{
    public partial class StockOrder
    {
        public int Id { get; set; }
        public int IdTheOrder { get; set; }
        public double? Amount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DateReturnToShop { get; set; }
        public int? TheStatus { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
