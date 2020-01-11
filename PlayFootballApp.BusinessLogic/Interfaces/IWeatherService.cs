using PlayFootballApp.BusinessLogic.Models.Home;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayFootballApp.BusinessLogic.Interfaces
{
    public interface IWeatherService
    {       
        WeatherViewModel? GetWeather(Guid pitchAvabilityId);
    }
}
