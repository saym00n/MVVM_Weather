using System.Net.Http;
using System.Windows.Input;
using MVVM_Weather.Commands;
using MVVM_Weather.Services;

namespace MVVM_Weather.ViewModels;

public class MainWindowViewModel : BaseViewModel
{
    readonly HttpClient client = new();
    #region title

    private readonly string _title = "Погода";
    public string Title => _title;

    #endregion

    #region city

    private string _city = "Ессентуки";
    public string City
    {
        get => _city;
        set => SetField(ref _city, value);
    }



    #endregion

    #region apikey

    private string _apikey = "9ce36cb3e37709aeadb72516b2e9f1b8";

    public string ApiKey
    {
        get => _apikey;
        set=> SetField(ref _apikey, value); }


    #endregion

    private WeatherModel _weather;

    public WeatherModel Weather
    {
        get
        {
           return _weather;
        }
    }



    private string _test = "0";

    public string Test
    {
        get => _test;
        set => SetField(ref _test, value);
    }

    #region GetWeatherCommand

    public ICommand GetWeatherCommand { get; }

    private async void OnGetWeatherCommandExecute(object p)
    {
        WeatherModel _weather = await new GetWeatherService().GetWeather(client, _city, _apikey);
        Test = _weather.ToString();
    }

    private bool CanGetWeatherCommandExecuted(object p) => true;
    #endregion

    public MainWindowViewModel()
    {
        GetWeatherCommand = new RelayCommand(OnGetWeatherCommandExecute, CanGetWeatherCommandExecuted);
    }
}