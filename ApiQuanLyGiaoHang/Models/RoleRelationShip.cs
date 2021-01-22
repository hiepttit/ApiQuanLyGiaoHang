using System;
using System.Collections.Generic;

#nullable disable

namespace ApiQuanLyGiaoHang.Models
{
    public partial class RoleRelationShip
    {
        public int IdMainRole { get; set; }
        public int IdUser { get; set; }

        public virtual TheRole IdMainRoleNavigation { get; set; }
        public virtual TheUser IdUserNavigation { get; set; }
    }
}
