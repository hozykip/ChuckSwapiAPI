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
        public async static Task<ChuckSearchApiResponse?> getRandom(string category)
        {
            return await APICall.Get<ChuckSearchApiResponse?>(baseUrl, $"jokes/random?category={category}");
        }
    }
}
