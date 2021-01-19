using System;
using System.Collections.Generic;

#nullable disable

namespace ApiQuanLyGiaoHang.Models
{
    public partial class TokenUser
    {
        public string IdToken { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Roles { get; set; }
    }
}
