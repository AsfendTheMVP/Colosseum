using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Colosseum.Models;
using Newtonsoft.Json;

namespace Colosseum.Services
{
    public class ApiServices
    {
        private string nowPlayingMoviesUrl = "http://colosseum.somee.com/api/NowPlayingMovies";
        private string upComingMoviesUrl = "http://colosseum.somee.com/api/UpComingMovies";
        private string orderApiUrl = "http://colosseum.somee.com/api/Orders";
        private string latestMoviesUrl = "http://colosseum.somee.com/api/LatestMovies";


        public async Task<List<NowPlayingMovie>> GetNowPlayingMovies()
        {
            var client = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, nowPlayingMoviesUrl);
            requestMessage.Headers.Add("ApiKey", "8e75a7f2-2b51-4360-b684-a14b1b233570");
            var responseMessage = await client.SendAsync(requestMessage);
            var movieResponse = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<NowPlayingMovie>>(movieResponse);
        }

        public async Task<List<UpComingMovie>> GetUpComingMovies()
        {
            var client = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, upComingMoviesUrl);
            requestMessage.Headers.Add("ApiKey", "8e75a7f2-2b51-4360-b684-a14b1b233570");
            var responseMessage = await client.SendAsync(requestMessage);
            var movieResponse = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<UpComingMovie>>(movieResponse);
        }

        public async Task<bool> Order(BookTicket bookTicket)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(bookTicket);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.Add("ApiKey", "8e75a7f2-2b51-4360-b684-a14b1b233570");
            var response = await client.PostAsync(orderApiUrl, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<LatestMovie>> GetLatestMovies()
        {
            var client = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, latestMoviesUrl);
            requestMessage.Headers.Add("ApiKey", "8e75a7f2-2b51-4360-b684-a14b1b233570");
            var responseMessage = await client.SendAsync(requestMessage);
            var movieResponse = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<LatestMovie>>(movieResponse);
        }


    }
}
