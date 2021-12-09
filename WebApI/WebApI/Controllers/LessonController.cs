using BLL.Classes;
using DAL;
using DAL.Classes;
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
    public class LessonController : ControllerBase
    {
        [HttpGet("AddLesson/{Name}/{BeginDate}/{Length}/{SchoolID}/{MagidID}")]
        public IActionResult AddLesson(string Name, string BeginDate, float Length, int SchoolID, int MagidID)
        {
            var BDate = DateTime.ParseExact(BeginDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            return Ok(LessonBll.AddLesson(Name, BDate, Length, SchoolID, MagidID));

        }
    

        [HttpGet("openLessonToCurrentDate/{SchoolID}")]
        public IActionResult openLessonToCurrentDate(int SchoolID)
        {
            return Ok(LessonDAL.openLessonsToCurrentDate(SchoolID));

        }

        [HttpGet("GetAllLessons/{SchoolID}")]
        public IActionResult GetListMagids(int SchoolID)
       {
            var a = LessonBll.getAllLessons(SchoolID);
            return Ok(a);
        }

        [HttpGet("try")]
        public IActionResult _try()
        {
            var a = IdListMessageDAL.downloadM("1/1/2/Hash");
            return Ok(a);
        }
    }
}
