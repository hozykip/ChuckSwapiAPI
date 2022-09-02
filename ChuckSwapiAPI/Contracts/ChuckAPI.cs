//using 

using ChuckSwapiAPI.Models;

namespace ChuckSwapiAPI.Contracts
{
    public class ChuckAPI
    {
        private static string baseUrl = "https://api.chucknorris.io/";

        public async static Task<List<string>> getCategories()
        {
            return await APICall.Get<List<string>>(baseUrl, "jokes/categories");
        }
        public async static Task<ChuckJokeApiResponse?> getRandom(string category)
        {
            return await APICall.Get<ChuckJokeApiResponse?>(baseUrl, $"jokes/random?category={category}");
        }
        
        public async static Task<ChuckSearchApiResponse?> searchJoke(string query, int page=1)
        {
            page = page == 0 ? 1 : page;

            var allResponse = await APICall.Get<ChuckSearchApiResponse?>(baseUrl, $"jokes/search?query={query}");


            return await APICall.Get<ChuckSearchApiResponse?>(baseUrl, $"jokes/search?query={query}");
        }


    }
}
