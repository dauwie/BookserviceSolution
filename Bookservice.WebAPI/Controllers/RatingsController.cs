using Bookservice.WebAPI.Models;
using Bookservice.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bookservice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerCrudBase<Rating, RatingRepository>
    {
        public RatingsController(RatingRepository ratingRepository) : base(ratingRepository)
        {
        }

        // GET: api/Ratings
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            return Ok(await repository.GetAllInclusive());
        }
    }
}