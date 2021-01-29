using System;
using System.Collections.Generic;

#nullable disable

namespace ApiQuanLyGiaoHang.Models
{
    public partial class TheUserView
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string IdNumber { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfIssueIdNumber { get; set; }
        public string PlaceOfIssueIdNumber { get; set; }
        public string TheAddress { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public int IdRole { get; set; }
    }
}
