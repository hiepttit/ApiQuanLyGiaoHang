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
    public class DeliveryOrdersController : ODataController
    {
        private QuanLyGiaoHangContext _db;
        public DeliveryOrdersController(QuanLyGiaoHangContext db)
        {
            _db = db;
        }
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.DeliveryOrders);
        }
        public async Task<IActionResult> Post([FromBody] DeliveryOrder delivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            delivery.Id = Guid.NewGuid().ToString();
            delivery.CreatedAt = DateTime.Now.Date;
            await _db.DeliveryOrders.AddAsync(delivery);
            await _db.SaveChangesAsync();
            return Ok(new Response { Status = "Success", Message = "Created successfully!" });
        }
    }
}
