using System;
using System.Collections.Generic;

#nullable disable

namespace ApiQuanLyGiaoHang.Models
{
    public partial class TheUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string Name { get; set; }
        public string IdNumber { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfIssueIdNumber { get; set; }
        public string PlaceOfIssueIdNumber { get; set; }
        public string TheAddress { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int IdRole { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
