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
    public class PublishersController : ControllerCrudBase<Publisher,PublisherRepository>
    {        
        public PublishersController(PublisherRepository publisherRepository): base(publisherRepository)
        {            
        }        
    }
}