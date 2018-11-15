using System.Collections.Generic;
using System.Threading.Tasks;
using Bookservice.Lib.DTO;
using Bookservice.Lib.Models;
using Bookservice.MVC.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Bookservice.MVC.Controllers
{
    public class PublishersController : Controller
    {
        string baseuri = "https://localhost:44343/api/publishers";

        public IActionResult Index()
        {
            string publisherUri = $"{baseuri}/basic";
            return View(WebApiHelper.GetApiResult<List<PublisherBasic>>(publisherUri));
        }

        public IActionResult Detail(int id)
        {
            string publisherUri = $"{baseuri}/{id}";
            ViewBag.Mode = "Detail";
            return View(WebApiHelper.GetApiResult<Publisher>(publisherUri));
        }

        public IActionResult Edit(int id)
        {
            string uri = $"{baseuri}/{id}";
            ViewBag.Mode = "Edit";
            return View("Detail", WebApiHelper.GetApiResult<Publisher>(uri));
        }

        public IActionResult Insert()
        {
            ViewBag.Mode = "Edit";
            return View("Detail", new Publisher());
        }

        [HttpPost]
        public async Task<IActionResult> Save(Publisher publisher)
        {
            if (publisher.Id != 0)
            {
                // update
                string uri = $"{baseuri}/{publisher.Id}";
                publisher = await WebApiHelper.PutCallAPI<Publisher, Publisher>(uri, publisher);
            }
            else
            {
                // insert
                string uri = $"{baseuri}";
                publisher = await WebApiHelper.PostCallAPI<Publisher, Publisher>(uri, publisher);
            }

            ViewBag.Mode = "Detail";
            return View("Detail", publisher);
        }

        public async Task<IActionResult> Delete(int id)
        {
            string uri = $"{baseuri}/{id}";
            Publisher publisher = await WebApiHelper.DelCallAPI<Publisher>(uri);
            return RedirectToAction("Index");
        }



    }
}