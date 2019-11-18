using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.ViewModels;
using WebApplication1.Services;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RouteController : Controller
    {
        private RouteService _RouteService;
        private SchoolService _SchoolService;
        public RouteController(RouteService RouteService, SchoolService SchoolService)
        {
            _RouteService = RouteService;
            _SchoolService = SchoolService;
        }
        
        [Route("Plot/calcDistance/{startLa:float}/{startLo:float}")]
        [HttpGet]
        public async Task<IEnumerable<SideList>> calcDistance(float startLa, float startLo )
        {
            List<School> schools = new List<School>();
            schools = await _SchoolService.FindAllAsync();

            IList<SideList> list = new List<SideList>();

            Route[] x = new Route[schools.Count];
            float[] startPoint = { startLa, startLo };

            for (int i = 0; i < 30; i++)
            {
                float[] y = { schools[i].latitude, schools[i].longitude };
                x[i] = await _RouteService.CalculaRotaAsync(startPoint, y);
                Debug.WriteLine(x[i].resourceSets[0].resources[0].travelDistance);
                Debug.WriteLine(i);

                list.Add(new SideList() { id = i, name = schools[i].nome, abr_nome = schools[i].abr_nome, distance = x[i].resourceSets[0].resources[0].travelDistance, location = y });
            }
            Debug.WriteLine("depois do for");


            return list.OrderBy(a => a.distance);
        }

    }
}
