using Api.Models;
using Newtonsoft.Json.Linq;
namespace Api.Services
{
    public class Services:IWeather  
    {
        public Weatherclass GetCurrent(String city)

                    {

                    var client = new HttpClient();

                    var url = $"https://api.weatherbit.io/v2.0/current?city={city}&key=60e31af63129425abbc75e0d11fea9b0";

                    var weatherData= client.GetStringAsync(url).Result;

                    var jsonData = JObject.Parse(weatherData);

                    var dataArray = jsonData["data"];

                    var firstItem = dataArray[0];

                    var descriptionData = firstItem["weather"];
                                


                    Weatherclass dataToReturn = new Weatherclass

                    {
                    City_name = dataArray[0].Value<String>("city_name"),
                    Date = DateTime.Parse(dataArray[0].Value<string>("datetime").Split(':')[0]),
                                    
                                    Description = descriptionData.Value<string>("description"),

                                    Pressure = dataArray[0].Value<float>("pres"),


                                    Temperature = dataArray[0].Value<float>("temp"),

                    };





                    return dataToReturn;

                    }

    
    public List<Weatherclass>  GetForecastData (String city){ 
                throw new NotImplementedException();

                    }
    


     public List<Weatherclass> GetHistoricalData(String startingDate, String endingDate, String city)

                    {

                    var client = new HttpClient();

                    var url = $"https://api.weatherbit.io/v2.0/history/daily?city={city}&start_date={startingDate}&end_date={endingDate}&key=60e31af63129425abbc75e0d11fea9b0";


                    var weatherData= client.GetStringAsync(url).Result;

                    var jsonData = JObject.Parse(weatherData);

                    var dataArray = jsonData["data"];

                    
                                


                    List<Weatherclass> dataToReturn = new List<Weatherclass>();

                    foreach(var data in dataArray)
                    {   
                    Weatherclass historyObject = new Weatherclass{

                    City_name = jsonData ["city_name"].ToString(),
                    Date = DateTime.Parse(data["datetime"].ToString()),
                                    
                    Description = " ",

                    Pressure = float.Parse(data["pres"].ToString()),


                                    Temperature = float.Parse(data["temp"].ToString())
                    };

                    dataToReturn.Add(historyObject);

                    };


            


                    return dataToReturn;

                    }




    }
}