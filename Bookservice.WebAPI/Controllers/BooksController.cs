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
    public class BooksController : ControllerBase
    {
        BookRepository _bookRepository;

        public BooksController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        //api/Books
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_bookRepository.List());
        }

        //api/Books/Basic
        [HttpGet]
        [Route("Basic")]
        public IActionResult GetBookBasic()
        {
            return Ok(_bookRepository.ListBasic());
        }
    }
}