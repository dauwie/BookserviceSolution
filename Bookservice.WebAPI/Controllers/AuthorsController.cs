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
    public class AuthorsController : ControllerBase
    {
        AuthorRepository _authorRepository;

        public AuthorsController(AuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        // GET: api/Authors
        [HttpGet]
        public IActionResult GetAuthors()
        {
            return Ok(_authorRepository.List());
        }

        // GET: api/Authors/Basic
        [HttpGet]
        [Route("Basic")]
        public IActionResult GetAuthorBasic()
        {
            return Ok(_authorRepository.ListBasic());
        }

        // GET: api/Authors/2
        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id)
        {
            return Ok(_authorRepository.GetById(id));
        }
    }
}