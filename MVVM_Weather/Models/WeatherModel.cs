using System.Collections.Generic;
using System;
using System.Linq;
using Newtonsoft.Json;

namespace MVVM_Weather
{
public class Location
{
    [JsonProperty("lon")]
    public double Longitude { get; set; }

    [JsonProperty("lat")]
    public double Latitude { get; set; }
}

public class Weather
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("main")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("icon")]
    public string IconId { get; set; }

    public string IconUrl { get { return $"https://openweathermap.org/img/w/{IconId}.png"; } }
}

public class Main
{
    [JsonProperty("temp")]
    public double Temperature { get; set; }

    [JsonProperty("feels_like")]
    public double TemperaturePerception { get; set; }

    [JsonProperty("temp_min")]
    public double TemperatureMin { get; set; }

    [JsonProperty("temp_max")]
    public double TemperatureMax { get; set; }

    [JsonProperty("pressure")]
    public int AtmosphericPressure { get; set; }

    [JsonProperty("humidity")]
    public int HumidityPercentage { get; set; }
}


public class Wind
{
    [JsonProperty("speed")]
    public double Speed { get; set; }

    [JsonProperty("deg")]
    public int Direction { get; set; }

    [JsonProperty("gust")]
    public double? Gust { get; set; }
}

public class Clouds
{
    [JsonProperty("all")]
    public int Percentage { get; set; }
}

public class Rain
{
    [JsonProperty("1h")]
    public double? PastHourVolume { get; set; }

    [JsonProperty("3h")]
    public double? Past3HoursVolume { get; set; }
}

public class Snow
{
    [JsonProperty("1h")]
    public double? PastHourVolume { get; set; }

    [JsonProperty("3h")]
    public double? Past3HoursVolume { get; set; }
}

public class Internal
{
    [JsonProperty("message")]
    public double Message { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("sunrise")]
    public long SunriseUnix { get; set; }

    public DateTime SunriseTime
    {
        get { return DateTimeOffset.FromUnixTimeSeconds(SunriseUnix).UtcDateTime; }
    }

    [JsonProperty("sunset")]
    public long SunsetUnix { get; set; }

    public DateTime SunsetTime
    {
        get { return DateTimeOffset.FromUnixTimeSeconds(SunsetUnix).UtcDateTime; }
    }
}

public class WeatherModel
{
    [JsonProperty("coord")]
    public Location Location { get; set; }

    [JsonProperty("weather")]
    public List<Weather> Weather { get; set; }

    [JsonProperty("base")]
    public string Base { get; set; }

    [JsonProperty("main")]
    public Main Main { get; set; }

    [JsonProperty("visibility")]
    public int Visibility { get; set; }

    [JsonProperty("wind")]
    public Wind Wind { get; set; }

    [JsonProperty("clouds")]
    public Clouds Clouds { get; set; }


    [JsonProperty("rain")]
    public Rain? Rain { get; set; }

    [JsonProperty("snow")]
    public Snow? Snow { get; set; }

    [JsonProperty("dt")]
    public long AnalysisDateUnix { get; set; }

    public DateTime AnalysisDate
    {
        get { return DateTimeOffset.FromUnixTimeSeconds(AnalysisDateUnix).UtcDateTime; }
    }

    [JsonProperty("sys")]
    public Internal Internal { get; set; }

    [JsonProperty("timezone")]
    public int Timezone { get; set; }

    [JsonProperty("id")]
    public long CityId { get; set; }

    [JsonProperty("name")]
    public string CityName { get; set; }

    [JsonProperty("cod")]
    public int StatusCode { get; set; }

    public override string ToString()
    {
        return CityName + " " + Main.Temperature + " " + Weather.First().Description;
    }
}}
