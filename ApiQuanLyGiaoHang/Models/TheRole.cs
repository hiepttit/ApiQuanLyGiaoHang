using System;
using System.Collections.Generic;

#nullable disable

namespace ApiQuanLyGiaoHang.Models
{
    public partial class TheRole
    {
        public TheRole()
        {
            RoleRelationShips = new HashSet<RoleRelationShip>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int IsMainRole { get; set; }
        public int? IsDeleted { get; set; }

        public virtual ICollection<RoleRelationShip> RoleRelationShips { get; set; }
    }
}
