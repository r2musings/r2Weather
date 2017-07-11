using System.Collections.Generic;

namespace r2weathernet.Models
{
    public class OpenWeatherResponse
    {
        public string Name { get; set; }

        public IEnumerable<WeatherDescription> Weather { get; set; }

        public Main Main { get; set; }

        public string Message { get; set; }

        public string Cod { get; set; }
    }

    public class WeatherDescription
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }

    public class Main
    {
        public string Temp { get; set; }
        public string Temp_Min { get; set; }
        public string Temp_Max { get; set; }
        public string Humidity { get; set; }
    }
}
