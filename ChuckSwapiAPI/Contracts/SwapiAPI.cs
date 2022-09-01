using ChuckSwapiAPI.Models;

namespace ChuckSwapiAPI.Contracts
{
    public class SwapiAPI
    {
        private static string baseUrl = "https://swapi.dev/api/";

        private async static Task<StarwarsApiResponse> getPeople(int page = 1)
        {
            page = page == 0 ? 1 : page;

            return await APICall.Get<StarwarsApiResponse>(baseUrl, $"people/?page={page}");
        }
        
        public async static Task<PaginatedResult<StarResult>> getAllPeople(int page = 1)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(baseUrl);

            var results = await getPeople(page); 

            var response = new PaginatedResult<StarResult>()
            {
                TotalItems = results.count,
                Items = results.results
            };

            return response;
        }
    }
}
