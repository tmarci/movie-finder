using MovieFinder.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Services
{
    class MovieService
    {
        private readonly Uri serverUrl = new Uri("https://api.themoviedb.org/3/");
        private readonly String apiKey = "b9b9fcf5afd4fedd8ba1d78e0a50109a";

        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" });
                return result;
            }
        }

        public async Task<MoviesPage> GetPopularMoviesPageAsync(int pageNumber)
        {
            return await GetAsync<MoviesPage>(new Uri(serverUrl, $"movie/popular?api_key={apiKey}&page={pageNumber}"));
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            return await GetAsync<Movie>(new Uri(serverUrl, $"movie/{id}?api_key={apiKey}"));
        }
    }
}
