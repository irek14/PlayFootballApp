using System;
using System.Collections.Generic;
using System.Text;

namespace PlayFootballApp.BusinessLogic.Models.Home
{
    public class WeatherViewModel
    {
        public double Temperature { get; set; }
        public double SensedTemperature { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public string Description { get; set; }
    }
}
