using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ApiQuanLyGiaoHang.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace ApiQuanLyGiaoHang.Authentication
{
    [AttributeUsage(AttributeTargets.All)]
    public class CustomAuthorization : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            var _db = context.HttpContext.RequestServices.GetService<QuanLyGiaoHangContext>();

            if (user.Identity.IsAuthenticated)
            {
                // check db a cache, xem co thong tin user hay khong
                var IDtoken = user.Claims.FirstOrDefault(c => c.Type == "jti");
                //var oldToken = _db.TokenUsers.Any(f => f.Id == IDtoken.Value);
                //if (oldToken)
                //{
                //    var role = Roles == null ? Roles : Roles.Split(",")[0];
                //    if (role == null) return;
                //    //var role = Roles.Split(",")[0];
                //    var isValid = user.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value == role);
                //    if (isValid) return;
                //    context.Result = new ForbidResult();
                //}
                //else
                //{
                //    context.Result = new UnauthorizedResult();
                //}
            }
            else
            {
                var IDtoken = user.Claims.FirstOrDefault(c => c.Type == "jti");
                //var oldToken = _db.TokenUsers.Any(f => f.Id == IDtoken.Value);
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
