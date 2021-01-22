using ApiQuanLyGiaoHang.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiQuanLyGiaoHang.Controllers
{
    public class WardController : ODataController
    {
        private QuanLyGiaoHangContext _db;
        public WardController(QuanLyGiaoHangContext db)
        {
            _db = db;
        }
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.Wards);
        }
    }
}
