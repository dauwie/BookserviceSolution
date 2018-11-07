using Bookservice.WebAPI.Models;
using Bookservice.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bookservice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerCrudBase<Reader, ReaderRepository>
    {
        public ReadersController(ReaderRepository readerRepository) : base(readerRepository)
        {
        }
    }
}