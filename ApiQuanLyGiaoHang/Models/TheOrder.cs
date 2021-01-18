﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ApiQuanLyGiaoHang.Models
{
    public partial class TheOrder
    {
        public int Id { get; set; }
        public int IdShop { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string TheAddresss { get; set; }
        public double? Cod { get; set; }
        public double? ShipFee { get; set; }
        public double? RealReceive { get; set; }
        public int? IsSuccess { get; set; }
        public int? IsInStock { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
