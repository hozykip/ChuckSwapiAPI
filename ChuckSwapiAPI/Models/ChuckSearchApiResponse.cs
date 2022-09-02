namespace ChuckSwapiAPI.Models
{
    public class ChuckJokeApiResponse
    {
        public List<string> categories { get; set; }
        public string created_at { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public string value { get; set; }
    }

    public class ChuckSearchApiResponse
    {
        public int total { get; set; }
        public List<ChuckJokeApiResponse> result { get; set; }
    }
}
