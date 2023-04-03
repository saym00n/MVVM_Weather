using System.Net.Http;
using System.Threading.Tasks;

namespace MVVM_Weather.Services;

public interface IWeatherService
{
    Task<WeatherModel> GetWeather(HttpClient client,string city, string apikey);

}