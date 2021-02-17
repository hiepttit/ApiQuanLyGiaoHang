using ApiQuanLyGiaoHang.Authentication;
using ApiQuanLyGiaoHang.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiQuanLyGiaoHang.Controllers
{
    public class OrdersController : ODataController
    {
        private QuanLyGiaoHangContext _db;
        public OrdersController(QuanLyGiaoHangContext db)
        {
            _db = db;
        }
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.TheOrders);
        }
        public async Task<IActionResult> Post([FromBody] TheOrder order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            order.Id= Guid.NewGuid().ToString();
            order.CreatedAt = DateTime.Now.Date;
            await _db.TheOrders.AddAsync(order);
            await _db.SaveChangesAsync();
            return Ok(new Response { Status = "Success", Message = "Created successfully!" });
        }
        //public async Task<IActionResult> Put([FromODataUri] int key, [FromBody] TheOrder order)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    else if (key != order.Id)
        //    {
        //        return BadRequest("The key from the url must match the key of the entity in the body");
        //    }
        //    var originalCustomer = await _db.TheUsers.FindAsync(key);
        //    if (originalCustomer == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        _db.Entry(originalCustomer).CurrentValues.SetValues(user);
        //        await _db.SaveChangesAsync();
        //    }
        //    return Updated(user);
        //}
        //[AcceptVerbs("PATCH", "MERGE")]
        //public async Task<IActionResult> Patch([FromODataUri] int key, [FromBody] Delta<TheOrder> order)
        //{
        //    object id;
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    else if (order.GetChangedPropertyNames().Contains("Id") && order.TryGetPropertyValue("Id", out id) && (int)id != key)
        //    {
        //        return BadRequest("The key from the url must match the key of the entity in the body");
        //    }
        //    TheUser updateOrder = await _db.TheOrders.FindAsync(key);
        //    if (updateOrder == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        updateOrder.UpdatedAt = DateTime.Now;
        //        order.Patch(updateOrder);
        //        await _db.SaveChangesAsync();
        //    }
        //    return Updated(updateOrder);
        //}
        //public async Task<IActionResult> Delete([FromODataUri] int key)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    TheUser updateOrder = await _db.TheOrders.FindAsync(key);
        //    if (updateOrder == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        updateOrder.DeletedAt = DateTime.Now;
        //        await _db.SaveChangesAsync();
        //    }
        //    return Updated(updateOrder);
        //}
    }
}
