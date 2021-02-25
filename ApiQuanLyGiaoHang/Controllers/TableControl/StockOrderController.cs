using ApiQuanLyGiaoHang.Authentication;
using ApiQuanLyGiaoHang.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiQuanLyGiaoHang.Controllers
{
    public class StockOrderController : ODataController
    {
        private QuanLyGiaoHangContext _db;
        public StockOrderController(QuanLyGiaoHangContext db)
        {
            _db = db;
        }
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.StockOrders);
        }
        public async Task<IActionResult> Post([FromBody] StockOrder stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(stock.Delaydate<= DateTime.Now.Date)
            {
                return Problem("Ngày phải lơn hơn ngày hiện tại!");
            }
            var old = _db.StockOrders.FirstOrDefault(p => p.IdTheOrder == stock.IdTheOrder && p.DeletedAt==null);
            if (old != null)
            {
                return Problem("Hàng đã có trong kho!");
            }
            var delivery = _db.DeliveryOrders.FirstOrDefault(p => p.IdTheOrder == stock.IdTheOrder);
            delivery.TheStatus = 1;
            stock.Id = Guid.NewGuid().ToString();
            stock.CreatedAt = DateTime.Now.Date;
            stock.TheStatus = 0;
            await _db.StockOrders.AddAsync(stock);
            await _db.SaveChangesAsync();
            return Ok(new Response { Status = "Success", Message = "Created successfully!" });
        }
    }
}
