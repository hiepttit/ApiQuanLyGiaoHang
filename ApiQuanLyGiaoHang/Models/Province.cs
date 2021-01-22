using System;
using System.Collections.Generic;

#nullable disable

namespace ApiQuanLyGiaoHang.Models
{
    public partial class Province
    {
        public Province()
        {
            Districts = new HashSet<District>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? TelephoneCode { get; set; }
        public string ZipCode { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsPublished { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<District> Districts { get; set; }
    }
}
