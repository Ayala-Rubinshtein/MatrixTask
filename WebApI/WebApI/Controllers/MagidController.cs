using BLL.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagidController : ControllerBase
    {
        [Route("GetListMagids")]
        public IActionResult GetListMagids()
        {
            var a = MagidBLL.GetListMagids();
            return Ok(a);

        }

    }
}
