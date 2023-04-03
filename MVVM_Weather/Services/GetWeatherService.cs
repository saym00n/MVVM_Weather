using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVVM_Weather.Services;

public class GetWeatherService : IWeatherService
{
    public async Task<WeatherModel> GetWeather(HttpClient client,string cityname,string apikey)
    {
        var weatherJson = await client.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?q={cityname}&appid={apikey}&lang=ru&units=metric");
        return JsonConvert.DeserializeObject<WeatherModel>(weatherJson);
    }

}