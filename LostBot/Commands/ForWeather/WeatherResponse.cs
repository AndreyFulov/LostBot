using LostBot.Commands.ForWeather;
using System;
using System.Collections.Generic;
using System.Text;

namespace LostBot.Commands
{
    public class WeatherResponse
    {
        public TemperatureInfo Main { get; set; }
        public WindInfo Wind { get; set; }
        public CloudsInfo Clouds { get; set; }
        public string Name { get; set; }
    }
}
