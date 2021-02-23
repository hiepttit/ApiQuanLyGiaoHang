using ApiQuanLyGiaoHang.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiQuanLyGiaoHang.Controllers.Api
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private QuanLyGiaoHangContext _db;
        public OrderController(QuanLyGiaoHangContext db)
        {
            _db = db;
        }
        [HttpGet]
        [Route("GetId")]
        public IActionResult GetId()
        {
            var res = from o in _db.Set<TheOrder>().AsNoTracking()
                      join d in _db.Set<DeliveryOrder>().AsNoTracking()
                      on o.Id equals d.IdTheOrder into detail
                      from d in detail.DefaultIfEmpty()
                      where d.Id == null && o.IsSuccess!=1
                      select new
                      {
                          o.Id,
                      };
            return Ok(res);
        }
        [HttpGet]
        [Route("GetInStockId")]
        public IActionResult GetInStockId()
        {
            var res = from o in _db.Set<TheOrder>().AsNoTracking()
                      join st in _db.Set<StockOrder>().AsNoTracking()
                      on o.Id equals st.IdTheOrder 
                      where o.IsSuccess != 1 && DateTime.Now.Date==st.Delaydate
                      select new
                      {
                          o.Id,
                      };
            return Ok(res);
        }
    }
}
