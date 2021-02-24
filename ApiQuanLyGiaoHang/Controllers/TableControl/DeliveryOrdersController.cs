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
            delivery.TheStatus = 0;
            delivery.CreatedAt = DateTime.Now.Date;
            await _db.DeliveryOrders.AddAsync(delivery);
            await _db.SaveChangesAsync();
            return Ok(new Response { Status = "Success", Message = "Created successfully!" });
        }
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IActionResult> Patch([FromODataUri] string key, [FromBody] Delta<DeliveryOrder> delivery)
        {
            object id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (delivery.GetChangedPropertyNames().Contains("Id") && delivery.TryGetPropertyValue("Id", out id) && id.ToString() != key)
            {
                return BadRequest("The key from the url must match the key of the entity in the body");
            }
            DeliveryOrder updatedelivery = _db.DeliveryOrders.FirstOrDefault(k=>k.IdTheOrder==key);
            if (updatedelivery == null)
            {
                return NotFound();
            }
            else
            {
                if (await DeleteStockOrder(key))
                {
                    updatedelivery.UpdatedAt = DateTime.Now;
                    delivery.Patch(updatedelivery);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    return NotFound();
                }
                
            }
            return Ok(new Response { Status = "Success", Message = "Updated successfully!" });
        }
        private async Task<bool> DeleteStockOrder(string idOrder)
        {
            StockOrder deleteStock = _db.StockOrders.FirstOrDefault(k => k.IdTheOrder == idOrder);
            if (deleteStock == null)
            {
                return false;
            }
            else
            {
                deleteStock.DeletedAt = DateTime.Now.Date;
                await _db.SaveChangesAsync();
            }
            return true;
        }
    }
}
