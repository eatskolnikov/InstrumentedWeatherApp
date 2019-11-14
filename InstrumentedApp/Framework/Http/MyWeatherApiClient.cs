using System;
using Refit;
using MyWeather.Model;
using System.Threading.Tasks;

namespace MyWeather
{
    public interface IMyWeatherApiClient
    {
        [Get("/current?access_key={apikey}&query={cityName}")]
        Task<WeatherResponse> GetWeatherFromCity(string cityName, string apikey);
    }
}