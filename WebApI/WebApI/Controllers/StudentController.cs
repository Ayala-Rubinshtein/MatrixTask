using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.classes;
using System.Diagnostics;

namespace WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllStudents")]
        public IActionResult GetAllStudentByIdSchool()
        {
            try
            {
                var allStudents = StudentBll.SelectAllStudents();
                return Ok(allStudents);
            }
            catch (Exception e)
            {
                Trace.TraceError(e.Message);
                return null;
            }
        }
    }
}
