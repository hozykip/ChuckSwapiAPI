using ChuckSwapiAPI.Contracts;
using ChuckSwapiAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChuckSwapiAPI.Controllers
{
    [Route("api/chuck")]
    [ApiController]
    public class ChuckController : ControllerBase
    {
        [HttpGet]
        [Route("categories")]
        public async Task<DefaultResponse<List<string>>> categories()
        {
            DefaultResponse<List<string>> response = new DefaultResponse<List<string>>("Failed to fetch categories");
            try
            {
                List<string> categories = await ChuckAPI.getCategories();

                response.status = Configs.ResponseCodes.SUCCESS;
                response.message = "Categories fetched successfully";
                response.data = categories;
            }
            catch(Exception e)
            {

            }

            return response;
        }
        
        [HttpGet]
        [Route("random")]
        public async Task<DefaultResponse<ChuckJokeApiResponse>> Random(string category)
        {
            DefaultResponse<ChuckJokeApiResponse> response = new DefaultResponse<ChuckJokeApiResponse>("Failed to fetch joke");
            try
            {
                ChuckJokeApiResponse? jokeResponse = await ChuckAPI.getRandom(category);

                if(jokeResponse.id != null)
                {
                    response.status = Configs.ResponseCodes.SUCCESS;
                    response.message = "Random joke fetched successfully";
                    response.data = jokeResponse;
                }

            }
            catch(Exception e)
            {

            }

            return response;
        }
    }
}
