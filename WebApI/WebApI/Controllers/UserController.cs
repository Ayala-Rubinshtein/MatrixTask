using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.classes;
using DTO;

namespace WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly UserBll _User;
        //public UserController(UserBll User) => _User = User;
        [HttpPost("GetUserByUserNameAndPassword")]
        public IActionResult GetUserByUserNameAndPassword([FromBody] LoginDTO _login)
        {
            try
            {

                var u = UserBll.GetUserByUserNameAndPassword(_login.UserName,_login.Password);
                return Ok(u);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}