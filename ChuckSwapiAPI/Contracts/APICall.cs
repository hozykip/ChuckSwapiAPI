namespace ChuckSwapiAPI.Contracts
{
    public class APICall
    {
        public async static Task<T> Get<T>(string baseUrl, string endPoint)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(baseUrl);


            var res = await client.GetAsync(endPoint);

            var results = await res.Content.ReadAsAsync<T>();

            return results;
        }
    }
}
