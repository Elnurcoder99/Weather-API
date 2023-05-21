using Api.Models;
namespace Api.Services
{
    public interface IWeather
    {
         Weatherclass GetCurrent (String city);

         List<Weatherclass>  GetHistoricalData (String startingDate, String endingDate, String city);

         List<Weatherclass>  GetForecastData (String city);
    }
}