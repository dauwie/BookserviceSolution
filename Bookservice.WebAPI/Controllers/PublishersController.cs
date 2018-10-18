using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookservice.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookservice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        PublisherRepository _publisherRepository;

        public PublishersController(PublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        // GET: api/Publishers
        [HttpGet]
        public IActionResult GetPublishers()
        {
            return Ok(_publisherRepository.List());
        }

        // GET: api/Publishers/2
        [HttpGet("{id}")]
        public IActionResult GetPublisher(int id)
        {
            return Ok(_publisherRepository.GetById(id));
        }
                     
    }
}