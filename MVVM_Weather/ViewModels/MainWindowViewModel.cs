﻿using MVVM_Weather.Commands;
using MVVM_Weather.Services;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows.Input;

namespace MVVM_Weather.ViewModels;

public class MainWindowViewModel : BaseViewModel
{
    private readonly HttpClient client = new();

    #region title

    private readonly string _title = "Погода";
    public string Title => _title;

    #endregion title

    #region city

    private string _city = "Ессентуки";

    public string City
    {
        get => _city;
        set => SetField(ref _city, value.Trim());
    }

    private string _maplink;

    public string MapLink
    {
        get => _maplink;
        set => SetField(ref _maplink, value + $"?appid={ApiKey}");
    }

    #endregion city

    #region apikey

    private string _apikey = "";

    public string ApiKey
    {
        get => _apikey;
        set => SetField(ref _apikey, value);
    }

    #endregion apikey

    #region weather

    private WeatherModel _weather;

    public WeatherModel Weather
    {
        get => _weather;
        set
        {
            SetField(ref _weather, value);
        }
    }

    #endregion weather

    private ObservableCollection<string> _obList = new();

    public ObservableCollection<string> ObList
    {
        get => _obList;
    }

    #region GetWeatherCommand

    public ICommand GetWeatherCommand { get; }

    private async void OnGetWeatherCommandExecute(object p)
    {
        Weather = await new GetWeatherService().GetWeather(client, _city, _apikey);
        if (!Weather.ToString().Equals(String.Empty))
        {
            ObList.Add(Weather.ToString());
            MapLink = (new MapModel() { lat = Weather.Location.Latitude, lon = Weather.Location.Longitude })
                .maplink;
        }
    }

    private bool CanGetWeatherCommandExecuted(object p) => true;

    #endregion GetWeatherCommand

    public MainWindowViewModel()
    {
        GetWeatherCommand = new RelayCommand(OnGetWeatherCommandExecute, CanGetWeatherCommandExecuted);
    }
}