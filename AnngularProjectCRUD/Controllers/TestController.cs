using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AnngularProjectCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
       private readonly DBContext db=new DBContext();
        public TestController()
        {

            
        }
        [HttpGet]
        public List<dynamic> Get()
        {
            return  db.Employees.ToList<dynamic>();
            //List<dynamic> emps = db.Employees.ToList<dynamic>();
           // return emps;
        }
    }
}
