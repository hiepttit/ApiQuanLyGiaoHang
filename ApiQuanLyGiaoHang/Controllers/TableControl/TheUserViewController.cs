using ApiQuanLyGiaoHang.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiQuanLyGiaoHang.Controllers
{
    public class TheUserViewController : ODataController
    {
        private QuanLyGiaoHangContext _db;
        public TheUserViewController(QuanLyGiaoHangContext db)
        {
            _db = db;
        }
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.TheUserViews);
        }
        public IActionResult Get([FromODataUri] string key)
        {
            return Ok(_db.TheUserViews.Where(p => p.IdRole == 3 && p.Id != key));
        }
    }
}
