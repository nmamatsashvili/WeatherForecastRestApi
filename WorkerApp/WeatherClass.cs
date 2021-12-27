using System;
using System.Net.Http;

namespace WorkerApp
{
    public class WeatherClass
    {
        public object getWeather(string city, int daysCount, out bool success) {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://api.openweathermap.org/data/2.5/forecast/daily?q={city}&cnt={daysCount}&units=metric&appid="),
                };
                using (var response = client.SendAsync(request).Result)
                {
                    response.EnsureSuccessStatusCode();
                    success = true;
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                success = false;
                return ex.Message;
            }
        }
    }
}
