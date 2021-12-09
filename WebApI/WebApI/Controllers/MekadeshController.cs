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
    public class MekadeshController : ControllerBase
    {
        [HttpGet("openTestToPhone")]
        public IActionResult openTestToPhone(string ApiExtension,string ApiPhone)

        {
            try
            {
                return Ok(MekadeshBll.openTestToPhone(ApiExtension, ApiPhone));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("updatePointsAndFinishTest")]
        public IActionResult updatePointsAndFinishTest(string ApiExtension, string ApiPhone)
        {
            try
            {
                return Ok(MekadeshBll.updatePointsAndFinishTest(ApiExtension,ApiPhone));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
