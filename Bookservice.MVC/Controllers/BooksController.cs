using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Bookservice.Lib.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bookservice.MVC.Controllers
{
    public class BooksController : Controller
    {
        string baseuri = "https://localhost:44343/api/books";

        public IActionResult Index()
        {
            string bookUri = $"{baseuri}/basic";
            return View(GetApiResult<List<BookBasic>>(bookUri));
        }

        public IActionResult Detail(int id)
        {
            string geekJokesUri = "https://geek-jokes.sameerkumar.website/api";
            string ipsumUri = "https://baconipsum.com/api/?type=meat-and-filler&paras=2&format=text";


            string bookUri = $"{baseuri}/basic";

            return View(GetApiResult<List<BookBasic>>(bookUri));
        }

        public T GetApiResult<T>(string uri)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                Task<string> response = httpClient.GetStringAsync(uri);
                return Task.Factory.StartNew(
                        () => JsonConvert.DeserializeObject<T>(response.Result)
                    ).Result;
            }
        }
    }
}