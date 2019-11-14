using System;
using InstrumentedApp.Framework.Model;
using Newtonsoft.Json;

namespace MyWeather.Model
{

    public partial class WeatherResponse
    {
        [JsonProperty("request")]
        public Request Request { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("current")]
        public Current Current { get; set; }
    }
}
