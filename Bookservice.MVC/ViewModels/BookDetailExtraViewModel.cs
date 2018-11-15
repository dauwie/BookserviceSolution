using Bookservice.Lib.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookservice.MVC.ViewModels
{
    public class BookDetailExtraViewModel
    {
        public BookDetail BookDetail { get; set; }
        public string AuthorJoke { get; set; }
        public string BookSummary { get; set; }
    }
}
