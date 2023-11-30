using System;
using System.Collections.Generic;

interface IWeatherSubject
{
    void AddWeatherObserver(IWeatherObserver weatherObserver);
    void RemoveWeatherObserver(IWeatherObserver weatherObserver);
    void NotifyWeatherObservers();
}

interface IWeatherObserver
{
    void UpdateWeather(string weatherMessage);
}

class WeatherStation : IWeatherSubject
{
    private List<IWeatherObserver> weatherObservers = new List<IWeatherObserver>();
    private string currentWeather;

    public void AddWeatherObserver(IWeatherObserver weatherObserver)
    {
        weatherObservers.Add(weatherObserver);
    }

    public void RemoveWeatherObserver(IWeatherObserver weatherObserver)
    {
        weatherObservers.Remove(weatherObserver);
    }

    public void NotifyWeatherObservers()
    {
        foreach (var observer in weatherObservers)
        {
            observer.UpdateWeather(currentWeather);
        }
    }

    public void SetCurrentWeather(string newWeather)
    {
        currentWeather = newWeather;
        NotifyWeatherObservers();
    }
}

class WeatherDisplay : IWeatherObserver
{
    private readonly string displayName;

    public WeatherDisplay(string displayName)
    {
        this.displayName = displayName;
    }

    public void UpdateWeather(string weatherMessage)
    {
        Console.WriteLine($"{displayName} received weather update: {weatherMessage}");
    }
}

class Program
{
    static void Main()
    {
        var weatherStation = new WeatherStation();

        var display1 = new WeatherDisplay("Display 1");
        var display2 = new WeatherDisplay("Display 2");

        weatherStation.AddWeatherObserver(display1);
        weatherStation.AddWeatherObserver(display2);

        weatherStation.SetCurrentWeather("Sunny");
        Console.WriteLine();

        weatherStation.RemoveWeatherObserver(display1);

        weatherStation.SetCurrentWeather("Rainy");
    }
}
