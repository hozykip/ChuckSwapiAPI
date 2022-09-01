using ChuckSwapiAPI.Contracts;
using ChuckSwapiAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChuckSwapiAPI.Controllers
{
    [Route("api/swapi")]
    [ApiController]
    public class SwapiController : ControllerBase
    {
        [HttpGet]
        [Route("people")]
        public async Task<DefaultResponse<PaginatedResult<StarResult>>> People(int page=1)
        {
            DefaultResponse<PaginatedResult<StarResult>> response =
                new DefaultResponse<PaginatedResult<StarResult>>(Configs.ResponseCodes.FAIL,"Failed to fetch star wars people");
            try
            {
                var callResult = await SwapiAPI.getAllPeople(page);

                response.status = Configs.ResponseCodes.SUCCESS;
                response.message = "Star wars fetched successfully";
                response.data = callResult;

            }catch(Exception e)
            {

            }
            return response;
        }
    }
}
