using System;
using Newtonsoft.Json;

namespace InstrumentedApp.Framework.Model
{
    public class Current
    {
        [JsonProperty("observation_time")]
        public string ObservationTime { get; set; }

        [JsonProperty("temperature")]
        public long Temperature { get; set; }

        [JsonProperty("weather_code")]
        public long WeatherCode { get; set; }

        [JsonProperty("weather_icons")]
        public Uri[] WeatherIcons { get; set; }

        public Uri IconUrl
        {
            get { return WeatherIcons[0]; }
        }
        public string Description
        {
            get { return string.Join(", ", WeatherDescriptions); }
        }

        [JsonProperty("weather_descriptions")]
        public string[] WeatherDescriptions { get; set; }

        [JsonProperty("wind_speed")]
        public long WindSpeed { get; set; }

        [JsonProperty("wind_degree")]
        public long WindDegree { get; set; }

        [JsonProperty("wind_dir")]
        public string WindDir { get; set; }

        [JsonProperty("pressure")]
        public long Pressure { get; set; }

        [JsonProperty("precip")]
        public long Precip { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("cloudcover")]
        public long Cloudcover { get; set; }

        [JsonProperty("feelslike")]
        public long Feelslike { get; set; }

        [JsonProperty("uv_index")]
        public long UvIndex { get; set; }

        [JsonProperty("visibility")]
        public long Visibility { get; set; }

        [JsonProperty("is_day")]
        public string IsDay { get; set; }
    }
}
