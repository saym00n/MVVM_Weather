using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_Weather.Services;

public class GetWeatherService : IWeatherService
{
    public async Task<WeatherModel> GetWeather(HttpClient client, string cityname, string apikey)
    {
        var weatherJson = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={cityname}&appid={apikey}&lang=ru&units=metric");
        switch (weatherJson.StatusCode)
        {
            case HttpStatusCode.Unauthorized:
                MessageBox.Show("Нет подключения к интернету или неверный API-ключ");
                break;

            case HttpStatusCode.NotFound:
                MessageBox.Show("Город не найден.");
                break;

            case HttpStatusCode.OK:
                Debug.WriteLine("OK");
                return JsonConvert.DeserializeObject<WeatherModel>(await weatherJson.Content.ReadAsStringAsync());
                break;
        }
        return new WeatherModel();
    }
}