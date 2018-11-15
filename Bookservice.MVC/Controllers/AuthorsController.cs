using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookservice.Lib.DTO;
using Bookservice.MVC.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Bookservice.MVC.Controllers
{
    public class AuthorsController : Controller
    {
        string baseuri = "https://localhost:44343/api/authors";

        public IActionResult Index()
        {
            string authorUri = $"{baseuri}/basic";
            return View(WebApiHelper.GetApiResult<List<AuthorBasic>>(authorUri));
        }
    }
}