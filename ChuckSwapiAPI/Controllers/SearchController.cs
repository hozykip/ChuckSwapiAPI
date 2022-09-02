using ChuckSwapiAPI.Contracts;
using ChuckSwapiAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChuckSwapiAPI.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        [HttpGet]
        public async Task<DefaultResponse<SearchResult>> Index([FromQuery] string query, int page = 1)
        {
            DefaultResponse<SearchResult> response = new()
            {
                status = Configs.ResponseCodes.FAIL,
                message = "Failed to get search results",
                data = new()
                {
                    chucks = new List<ChuckJokeApiResponse>(),
                    swapi = new PaginatedResult<StarResult>
                    {
                        TotalItems = 0,
                        Items = new List<StarResult>()
                    }
                }
            };

            try
            {
                PaginatedResult<StarResult>? swapiCall = response.data.swapi;
                ChuckSearchApiResponse? chuckCall = new ChuckSearchApiResponse { total = 0, result = new List<ChuckJokeApiResponse>() };
                if (page > 1)
                {
                    //only swapi
                    swapiCall = await SwapiAPI.searchPeople(query, page);
                }
                else
                {
                    swapiCall = await SwapiAPI.searchPeople(query, page);
                    chuckCall = await ChuckAPI.searchJoke(query);
                }


                response.status = Configs.ResponseCodes.SUCCESS;
                response.message = "Search complete";
                response.data.chucks = chuckCall != null ? 
                    chuckCall.result != null ? 
                        chuckCall.result : new List<ChuckJokeApiResponse>() : new List<ChuckJokeApiResponse>();
                response.data.swapi = swapiCall != null ? swapiCall : new PaginatedResult<StarResult>()
                {
                    Items = new List<StarResult>(),
                    TotalItems = 0
                };

                if(response.data.swapi.Items == null)
                {
                    response.data.swapi.Items = new List<StarResult>();
                }
                if(response.data.chucks == null)
                {
                    response.data.chucks = new List<ChuckJokeApiResponse>();
                }
            }
            catch (Exception e)
            {
                //
            }

            return response;
        }
    }
}
