namespace MVVM_Weather;

public class MapModel
{
    public double lon { get; set; } = 0;
    public double lat { get; set; } = 0;

    public string maplink
    {
        get => $"https://tile.openweathermap.org/map/clouds_new/1/{lat}/{lon}.png";
    }
}