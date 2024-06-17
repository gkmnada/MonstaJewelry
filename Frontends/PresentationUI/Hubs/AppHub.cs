using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using PresentationUI.TableDependencies.Entities;
using PresentationUI.TableDependencies.Services;
using System.Globalization;

namespace PresentationUI.Hubs
{
    public class AppHub : Hub
    {
        private readonly ICommentService _commentService;

        public AppHub(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task SendCommentCount(string id)
        {
            var values = _commentService.GetCommentCount(id);
            await Clients.All.SendAsync("ReceiveCommentCount", values);
        }

        public async Task SendCurrencyUSD()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=USD&to=TRY&amount=1"),
                Headers =
    {
        { "x-rapidapi-key", "94bf1fc17dmshc9d6de910045025p141f1cjsnb8c3bc555aa3" },
        { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Currency>(body);

                var numberFormatInfo = new NumberFormatInfo
                {
                    NumberDecimalSeparator = ",",
                    NumberGroupSeparator = string.Empty
                };

                await Clients.All.SendAsync("ReceiveCurrencyUSD", Math.Round(values.result, 2).ToString("N2", numberFormatInfo));
            }
        }

        public async Task SendCurrencyEUR()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=EUR&to=TRY&amount=1"),
                Headers =
    {
        { "x-rapidapi-key", "94bf1fc17dmshc9d6de910045025p141f1cjsnb8c3bc555aa3" },
        { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Currency>(body);

                var numberFormatInfo = new NumberFormatInfo
                {
                    NumberDecimalSeparator = ",",
                    NumberGroupSeparator = string.Empty
                };

                await Clients.All.SendAsync("ReceiveCurrencyEUR", Math.Round(values.result, 2).ToString("N2", numberFormatInfo));
            }
        }
    }
}
