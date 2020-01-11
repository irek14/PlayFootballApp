using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlayFootballApp.BusinessLogic.Interfaces;
using PlayFootballApp.BusinessLogic.Services.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace PlayFootballApp.BusinessLogic.Services
{
    public class WeatherService : IWeatherService
    {
        public void GetWeather()
        {
            JObject jsonData = JObject.Parse(new System.Net.WebClient().DownloadString("http://api.openweathermap.org/data/2.5/forecast?q=Warsaw,pl&APPID=94c9b6af33c09d8815fd8a2554fc395b&units=metric&lang=pl"));
            if (jsonData.SelectToken("cod").ToString() == "200")
            {
                JObject res = jsonData as JObject;

                RootObject album = res.ToObject<RootObject>();

                var a = 2;
            }
            else
            {
                
            }
        }
    }
}
