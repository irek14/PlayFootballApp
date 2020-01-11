using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlayFootballApp.BusinessLogic.Interfaces;
using PlayFootballApp.BusinessLogic.Services.Helpers;
using PlayFootballApp.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlayFootballApp.BusinessLogic.Models.Home;

namespace PlayFootballApp.BusinessLogic.Services
{
    public class WeatherService : IWeatherService
    {
        PlayFootballContext _context;

        public WeatherService(PlayFootballContext context)
        {
            _context = context;
        }

        public WeatherViewModel? GetWeather(Guid pitchAvabilityId)
        {
            JObject jsonData = JObject.Parse(new System.Net.WebClient().DownloadString("http://api.openweathermap.org/data/2.5/forecast?q=Warsaw,pl&APPID=94c9b6af33c09d8815fd8a2554fc395b&units=metric&lang=pl"));
            if (jsonData.SelectToken("cod").ToString() == "200")
            {
                JObject res = jsonData as JObject;
                RootObject root = res.ToObject<RootObject>();

                var avability = _context.PitchAvailability.Include(x => x.PitchOpenHours).Where(x => x.Id == pitchAvabilityId).FirstOrDefault();
                if (avability == null)
                    return null;

                string[] hourMinute = avability.PitchOpenHours.StartHour.Split(":");
                DateTime date = new DateTime(avability.OpenDate.Year, avability.OpenDate.Month, avability.OpenDate.Day, int.Parse(hourMinute[0]), int.Parse(hourMinute[1]),0);
                var currentDt = (Int32)(date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                int i = 0;
                while(currentDt > root.list[i].dt && i<root.list.Count)
                    i++;

                if (i == root.list.Count)
                    return null;

                return new WeatherViewModel()
                {
                    Humidity = root.list[i].main.humidity,
                    Pressure = root.list[i].main.pressure,
                    Temperature = root.list[i].main.temp,
                    SensedTemperature = Math.Round((root.list[i].main.temp + root.list[i].main.feels_like),2),
                    WindSpeed = root.list[i].wind.speed
                };
            }
            else
            {
                return null;
            }
        }
    }
}
