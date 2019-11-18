using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Data;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Web;

namespace WebApplication1.Services
{
    public class SchoolService
    {
        private SchoolContext _context;
        public SchoolService(SchoolContext context)
        {
            _context = context;
        }
        public async Task<List<School>> FindAllAsync()
        {
            return await _context.Schools.ToListAsync();
        }

        public async Task ClearDBAsync()
        {
            try
            {
                _context.RemoveRange(_context.Schools);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
            }

        }

        public async Task UpdateDBAsync(IList<School> schools)
        {
            _context.AddRange(schools);
            await _context.SaveChangesAsync();
        }
        public async Task<IList<School>> ReadApiAsync()
        {
            HttpClient client = new HttpClient();

            string result = await client.GetStringAsync("https://dadosabertos.poa.br/api/3/action/datastore_search?resource_id=5579bc8e-1e47-47ef-a06e-9f08da28dec8");
            JObject lista_json = JObject.Parse(result);
            IList<JToken> tokens = lista_json["result"]["records"].Children().ToList();
            IList<School> schools = new List<School>();

            foreach (JToken token in tokens)
            {
                School record = token.ToObject<School>();
                schools.Add(record);
            }

            return schools;
        }

    }
}
