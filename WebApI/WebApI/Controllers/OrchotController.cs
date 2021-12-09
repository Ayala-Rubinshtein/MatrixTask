using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Classes;

namespace WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrchotController : ControllerBase
    {
        [HttpGet("updateAngGetPoints")]
        public IActionResult updateAngGetPoints(string ApiEnterID,string ApiExtension)
        {
            try
            {
                string s = OrchotBll.TakeCodeFromApiEnterID(ApiEnterID);
                return Ok(OrchotBll.updateAngGetPoints(s, ApiExtension));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getAllPoints")]
        public IActionResult getAllPoints(string ApiEnterID)
        {
            try
            {
                string s = OrchotBll.TakeCodeFromApiEnterID(ApiEnterID);
                return Ok(OrchotBll.getAllPoints(s));
            }
            catch (Exception e)
            {
                return Ok(0);
            }
        }

        [HttpGet("openTestToStudent")]
        public IActionResult openTestToStudent(string ApiEnterID, string ApiExtension)
        
        {
            try
            {
                string s = OrchotBll.TakeCodeFromApiEnterID(ApiEnterID);
                return Ok(OrchotBll.openTestToStudent(s, ApiExtension));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("finishTest")]
        public IActionResult finishTest(string ApiEnterID, string ApiExtension)

        {
            try
            {
                string s = OrchotBll.TakeCodeFromApiEnterID(ApiEnterID);
                return Ok(OrchotBll.finishTest(s, ApiExtension));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
