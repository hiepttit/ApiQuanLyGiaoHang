using ApiQuanLyGiaoHang.Authentication;
using ApiQuanLyGiaoHang.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiQuanLyGiaoHang.Controllers.TableControl
{
    public class BasicSalaryController : ODataController
    {
        private QuanLyGiaoHangContext _db;
        public BasicSalaryController(QuanLyGiaoHangContext db)
        {
            _db = db;
        }
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.BasicSalaries);
        }
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IActionResult> Patch([FromODataUri] int key, [FromBody] Delta<BasicSalary> order)
        {
            object id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (order.GetChangedPropertyNames().Contains("Id") && order.TryGetPropertyValue("Id", out id) && (int)id != key)
            {
                return BadRequest("The key from the url must match the key of the entity in the body");
            }
            BasicSalary updateSalary = await _db.BasicSalaries.FindAsync(key);
            if (updateSalary == null)
            {
                return NotFound();
            }
            else
            {
                updateSalary.UpdatedAt = DateTime.Now;
                order.Patch(updateSalary);
                await _db.SaveChangesAsync();
            }
            return Ok(new Response { Status = "Success", Message = "Updated successfully!" });
        }
    }
}
