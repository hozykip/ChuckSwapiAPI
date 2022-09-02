using ChuckSwapiAPI.Models;

namespace ChuckSwapiAPI.Contracts
{
    public class SwapiAPI
    {
        private static string baseUrl = "https://swapi.dev/api/";

        
        
        public async static Task<PaginatedResult<StarResult>> getAllPeople(int page = 1)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(baseUrl);

            page = page == 0 ? 1 : page;

            var results = await APICall.Get<StarwarsApiResponse>(baseUrl, $"people/?page={page}");

            var response = new PaginatedResult<StarResult>()
            {
                TotalItems = results.count,
                Items = results.results
            };

            return response;
        }
        
        public async static Task<PaginatedResult<StarResult>> searchPeople(string query,int page = 1)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(baseUrl);

            page = page == 0 ? 1 : page;

            var results = await APICall.Get<StarwarsApiResponse>(baseUrl, $"people/?search={query}&page={page}");

            var response = new PaginatedResult<StarResult>()
            {
                TotalItems = results.count,
                Items = results.results
            };

            return response;
        }
    }
}
