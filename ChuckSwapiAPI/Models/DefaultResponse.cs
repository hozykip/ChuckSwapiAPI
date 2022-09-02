namespace ChuckSwapiAPI.Models
{
    public class DefaultResponse<T>
    {
        public DefaultResponse()
        {
            this.status = Configs.ResponseCodes.FAIL;
        }
        public DefaultResponse(Configs.ResponseCodes status)
        {
            this.status = status;
        }
        
        public DefaultResponse(Configs.ResponseCodes status, string message)
        {
            this.status = status;
            this.message = message;
        }
        
        public DefaultResponse(string message)
        {
            this.status = Configs.ResponseCodes.FAIL;
            this.message = message;
        }
        
        public DefaultResponse(Configs.ResponseCodes status, string message, T data)
        {
            this.status = status;
            this.message = message;
            this.data = data;
        }

        public Configs.ResponseCodes status { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }

    public class PaginatedResult<T>
    {
        public int TotalItems { get; set; } = 0;
        public List<T> Items { get; set; } = new List<T>();
    }

    //public class SearchResult<T,M>
    //{
    //    public T tResult { get; set; }
    //    public M mResult { get; set; }
    //}

    public class SearchResult
    {
        public PaginatedResult<StarResult> swapi { get; set; }
        public List<ChuckJokeApiResponse> chucks { get; set; }
    }
}
