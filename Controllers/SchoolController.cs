using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;
using System.Diagnostics;


namespace WebApplication1.Controllers
{
    public class SchoolController : Controller
    {
        private SchoolService _SchoolService;
        public SchoolController(SchoolService SchoolService)
        {
            _SchoolService = SchoolService;
        }

        [HttpGet]
        [Route("School/Index")]
        public async Task<IEnumerable<School>> Index()
        {
            List<School> x = new List<School>();
            x = await _SchoolService.FindAllAsync();

            return x;
        }

        [HttpPost]
        [Route("School/UpdateSchoolsDb")]
        public async Task UpdateSchoolsDb()
        {
            IList<School> x = await _SchoolService.ReadApiAsync();
            await _SchoolService.ClearDBAsync();
            await _SchoolService.UpdateDBAsync(x);
        }
    }
}