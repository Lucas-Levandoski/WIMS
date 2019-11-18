using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.ViewModels;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace WebApplication1.Services
{
    public class RouteService
    {
        public async Task<Route> CalculaRotaAsync(float[] StartPin, float[] EndPin)
        {
            HttpClient client = new HttpClient();

            Debug.WriteLine("Calculando rota");
            Debug.WriteLine("http://dev.virtualearth.net/REST/V1/Routes/Driving?o=json&wp.0=" +
                StartPin[0].ToString().Replace(",", ".") + "," +
                StartPin[1].ToString().Replace(",", ".") + "&wp.1=" +
                EndPin[0].ToString().Replace(",", ".") + "," +
                EndPin[1].ToString().Replace(",", ".") +
                "&avoid=minimizeTolls&key=Ah_WM7V5cekTjFYg7mpxoZwBhbJos3PW9pm8UONTXjq7L9IKC4LH0yXwhWxunlCo");

            string result = await client.GetStringAsync(
                "http://dev.virtualearth.net/REST/V1/Routes/Driving?o=json&wp.0=" + 
                StartPin[0].ToString().Replace(",", ".") + "," + 
                StartPin[1].ToString().Replace(",", ".") + "&wp.1=" + 
                EndPin[0].ToString().Replace(",", ".") + "," + 
                EndPin[1].ToString().Replace(",", ".") + 
                "&avoid=minimizeTolls&key=Ah_WM7V5cekTjFYg7mpxoZwBhbJos3PW9pm8UONTXjq7L9IKC4LH0yXwhWxunlCo"
                );

            Route route = new Route();
            route = JsonConvert.DeserializeObject<Route>(result);

            return route;
        }
    }
}
