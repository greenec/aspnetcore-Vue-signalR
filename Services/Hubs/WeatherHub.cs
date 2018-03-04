using Microsoft.AspNetCore.SignalR;
using RestSharp;
using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using Vue2SpaSignalR.Models.OpenWeatherModels;

namespace Vue2SpaSignalR.Services.Hubs
{    
    public class WeatherHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            // TODO: on connect, send the current forecast to the client
            await Clients.Client(Context.ConnectionId).InvokeAsync("weather", new List<string>());
        }
    }

    public class Weather : HostedService
    {
        public Weather(IHubContext<WeatherHub> context)
        {
            Clients = context.Clients;
        }

        private IHubClients Clients { get; }

        private List<WeatherForecast> _forecast = new List<WeatherForecast>();
        private DateTime _lastrun = DateTime.Now;

        public async Task UpdateWeatherForecasts()
        {
            if (DateTime.Now.Subtract(_lastrun).TotalMinutes >= 10)
            {
                await UpdateForecast("18040");
            }

            await Clients.All.InvokeAsync("weather", _forecast);
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await UpdateForecast("18040");

            while (true)
            {
                await UpdateWeatherForecasts();

                var task = Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
                try
                {
                    await task;
                }
                catch (TaskCanceledException)
                {
                    return;
                }
            }
        }

        private async Task UpdateForecast(string zip)
        {
            RestClient client = new RestClient("https://api.openweathermap.org");
            RestRequest request = new RestRequest("data/2.5/forecast?zip={zip},us&APPID={apikey}", Method.GET);

            request.AddUrlSegment("zip", zip);
            request.AddUrlSegment("apikey", "");

            var response = await client.ExecuteTaskAsync(request);
            var json = JsonConvert.DeserializeObject<ExtendedWeatherReport>(response.Content);

            _forecast = json.List.Select(x => new WeatherForecast
            {
                DateFormatted = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(x.Dt).ToLocalTime().ToString("g"),
                TemperatureC = (int)(x.Main.Temp - 273.15),
                Summary = x.Weather.First().Main + " - " + x.Weather.First().Description
            }).ToList();

            _lastrun = DateTime.Now;
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }
    }
}
