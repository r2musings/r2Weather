using System;
using System.Linq;

namespace r2weathernet.Models
{
    public class WeatherResult
    {
        public WeatherResult(OpenWeatherResponse openWeatherResponse)
        {
            CurrentTemp = Convert.ToInt32(Convert.ToDecimal(openWeatherResponse.Main.Temp));
            MinTemp = Convert.ToInt32(Convert.ToDecimal(openWeatherResponse.Main.Temp_Min));
            MaxTemp = Convert.ToInt32(Convert.ToDecimal(openWeatherResponse.Main.Temp_Max));
            Humidity = Convert.ToInt32(Convert.ToDecimal(openWeatherResponse.Main.Humidity));
            Summary = string.Join(",", openWeatherResponse.Weather.Select(x => x.Main));
            City = openWeatherResponse.Name;
        }

        public int CurrentTemp { get; set; }

        public int MinTemp { get; set; }

        public int MaxTemp { get; set; }

        public int Humidity { get; set; }

        public string City { get; set; }

        public string Zip { get; set; }

        public string Summary { get; set; }
    }
}
