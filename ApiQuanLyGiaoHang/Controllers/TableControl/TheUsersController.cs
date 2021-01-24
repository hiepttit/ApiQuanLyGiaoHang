using ApiQuanLyGiaoHang.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiQuanLyGiaoHang.Controllers
{
    public class TheUsersController : ODataController
    {
        private QuanLyGiaoHangContext _db;
        public TheUsersController(QuanLyGiaoHangContext db)
        {
            _db = db;
        }
        [EnableQuery]
        //public IActionResult Get()
        //{
        //    return Ok(_db.TheUsers);
        //}
        public IActionResult Get()
        {
            var users = _db.TheUsers.Select(p => new { p.Id, p.Name, p.IdNumber,p.PhoneNumber, p.DateOfIssueIdNumber,p.PlaceOfIssueIdNumber,p.TheAddress,p.BankAccountNumber,p.BankName,p.IdRole});                 
            return Ok(users);
        }
        [EnableQuery]
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_db.TheUsers.Where(p => p.IdRole == key && p.IdRole != 1).SelectMany(m => m.Name));
        }
        public async Task<IActionResult> Post([FromBody] TheUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.TheUsers.Add(user);
            await _db.SaveChangesAsync();
            return Created(user);
        }
        public async Task<IActionResult> Put([FromODataUri] int key, [FromBody] TheUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (key != user.Id)
            {
                return BadRequest("The key from the url must match the key of the entity in the body");
            }
            var originalCustomer = await _db.TheUsers.FindAsync(key);
            if (originalCustomer == null)
            {
                return NotFound();
            }
            else
            {
                _db.Entry(originalCustomer).CurrentValues.SetValues(user);
                await _db.SaveChangesAsync();
            }
            return Updated(user);
        }
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IActionResult> Patch([FromODataUri] int key, [FromBody] Delta<TheUser> user)
        {
            object id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (user.GetChangedPropertyNames().Contains("Id") && user.TryGetPropertyValue("Id", out id) && (int)id != key)
            {
                return BadRequest("The key from the url must match the key of the entity in the body");
            }
            TheUser updateUser = await _db.TheUsers.FindAsync(key);
            if (updateUser == null)
            {
                return NotFound();
            }
            else
            {
                user.Patch(updateUser);
                await _db.SaveChangesAsync();
            }
            return Updated(updateUser);
        }
        public async Task<IActionResult> Delete([FromODataUri] int key)
        {
            TheUser user = await _db.TheUsers.FindAsync(key);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                _db.TheUsers.Remove(user);
                await _db.SaveChangesAsync();
                return NoContent();
            }
        }
    }
}
