using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiQuanLyGiaoHang.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace ApiQuanLyGiaoHang.Controllers
{
    public class RolesController : ODataController
    {
        private QuanLyGiaoHangContext _db;
        public RolesController(QuanLyGiaoHangContext db)
        {
            _db = db;
        }
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.TheRoles);
        }
    }
}
