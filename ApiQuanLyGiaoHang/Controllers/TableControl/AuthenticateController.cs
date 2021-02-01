using ApiQuanLyGiaoHang.Authentication;
using ApiQuanLyGiaoHang.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApiQuanLyGiaoHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly QuanLyGiaoHangContext _db;
        private readonly IConfiguration _configuration;
        public AuthenticateController(IConfiguration configuration, QuanLyGiaoHangContext db)
        {
            _configuration = configuration;
            _db = db;
        }
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
        private bool CheckPasswordUser(TheUser user, string password)
        {
            if (user != null)
            {
                var check = _db.TheUsers.FirstOrDefault(f => f.UserName == user.UserName && f.Pwd == MD5Hash(password));
                if (check != null) return true;
            }
            return false;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var user = _db.TheUsers.FirstOrDefault(f => f.UserName == model.Username);
                if (user != null && CheckPasswordUser(user, model.Password))
                {
                    //var userRoles = from u in _db.Set<TheUser>().AsNoTracking()

                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };
                    //authClaims.Add(new Claim(ClaimTypes.Role, userRoles.Name));

                    //foreach (var userRole in userRoles)
                    //{
                    //    var role = _db.TheRoles.FirstOrDefault(f => f.Id == userRole.Id);
                    //    if (role != null)
                    //    {
                    //        authClaims.Add(new Claim(ClaimTypes.Role, role.Name));
                    //    }

                    //}

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddDays(1),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );

                    // luu vao db a
                    var loginToken = new JwtSecurityTokenHandler().WriteToken(token);
                    var oldToken = _db.TokenUsers.FirstOrDefault(x => x.IdToken == loginToken);
                    if (oldToken == null)
                    {
                        var inFoToken = authClaims.FirstOrDefault(f => f.Type == "jti");
                        //oldToken = new TokenUser { IdToken = inFoToken.Value, UserName = user.UserName, Token = loginToken, Roles=userRoles.Name };
                        await _db.TokenUsers.AddAsync(oldToken);
                        await _db.SaveChangesAsync();
                    }

                    return Ok(new
                    {
                        token = loginToken,
                        expiration = token.ValidTo
                    });
                }
                return Unauthorized();
            }
            catch (Exception exception)
            {
                return Ok(new
                {
                    ErrorMessage = exception.Message,
                    Source = exception.Source,
                    StackTrace = exception.StackTrace,
                    Target = exception.TargetSite?.ToString(),
                    InnerExceptionMessage = exception.InnerException?.Message
                });
            }
        }
        //[HttpPost]
        //[Route("register")]
        //public async Task<IActionResult> Register([FromBody] RegisterModel model)
        //{
        //    var old = _db.TheUsers.FirstOrDefault(f => f.UserName == model.Username);
        //    if (old == null)
        //    {
        //        old = new TheUser
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            UserName = model.Username,
        //            Email = model.Email,
        //            SecurityStamp = Guid.NewGuid().ToString(),
        //            PasswordHash = MD5Hash(model.Password)
        //        };
        //        await _db.TheUsers.AddAsync(old);
        //        var roleUser = _db.TheRoles.FirstOrDefault(f => f.Name == UserRoles.User);
        //        if (roleUser == null)
        //        {
        //            roleUser = new TheRole { Id = Guid.NewGuid().ToString(), Name = UserRoles.User };
        //            await _db.TheRoles.AddAsync(roleUser);
        //        }
        //        var UserRole = _db.TheRoles.FirstOrDefault(f => f.RoleId == roleUser.Id && f.UserId == old.Id);
        //        if (UserRole == null)
        //        {
        //            UserRole = new TheRole { RoleId = roleUser.Id, UserId = old.Id };
        //            await _db.TheRoles.AddAsync(UserRole);
        //        }

        //        await _db.SaveChangesAsync();
        //        return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        //    }
        //    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
        //}

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] TheUser model)
        {
            var old = await _db.TheUsers.FirstOrDefaultAsync(f => f.UserName == model.UserName);
            if (old == null)
            {
                model.Pwd = MD5Hash(model.Pwd);
                model.Id = Guid.NewGuid().ToString();
                model.CreatedAt = DateTime.Now.Date;

                //old = new TheUser
                //{
                //    Id = Guid.NewGuid().ToString(),
                //    UserName = model.UserName,
                //    Name = model.Name,
                //    Pwd = MD5Hash(model.Pwd),
                //    IdNumber=model.IdNumber,
                //    BankAccountNumber=model.BankAccountNumber,
                //    BankName=model.BankName,
                //    DateOfIssueIdNumber=model.DateOfIssueIdNumber,
                //    PhoneNumber=model.PhoneNumber,
                //    PlaceOfIssueIdNumber=model.PlaceOfIssueIdNumber,
                //    TheAddress=model.TheAddress,
                //    IdRole =model.IdRole,
                //};
                await _db.TheUsers.AddAsync(model);
                var re = new RoleRelationShip
                {
                    IdUser = model.Id,
                    IdMainRole = model.IdRole
                };
                await _db.RoleRelationShips.AddAsync(re);
                await _db.SaveChangesAsync();
                return Ok(new Response { Status = "Success", Message = "User created successfully!" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
        }

        [HttpPost]
        [Route("logout")]
        [CustomAuthorization]
        public async Task<IActionResult> Logout()
        {
            var IDtoken = User.Claims.FirstOrDefault(c => c.Type == "jti");
            var token = _db.TokenUsers.FirstOrDefault(f => f.IdToken == IDtoken.Value);
            if (token != null)
            {
                _db.TokenUsers.Remove(token);
                await _db.SaveChangesAsync();
                return Ok(new Response { Status = "Success", Message = "Logout Success!" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Logout Fail!" });
        }
    }
}
