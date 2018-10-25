using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookservice.WebAPI.Models;
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

        //PUT: api/Publishers/2
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublisher([FromRoute] int id, [FromBody] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != publisher.Id)
            {
                return BadRequest();
            }
            Publisher updatedPublisher = await _publisherRepository.Update(publisher);
            if(updatedPublisher == null)
            {
                return NotFound();
            }
            return Ok(updatedPublisher);
        }

        //POST: api/publishers
        [HttpPost]
        public async Task<IActionResult> PostPublisher([FromBody] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _publisherRepository.Add(publisher);

            return CreatedAtAction("GetPublisher", new { id = publisher.Id }, publisher);
        }    
        
        //DELETE: api/Publishers/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher ([FromRoute] int id)
        {
            var publisher = await _publisherRepository.Delete(id);
            if(publisher == null)
            {
                return NotFound();
            }

            return Ok(publisher);
        }
    }
}