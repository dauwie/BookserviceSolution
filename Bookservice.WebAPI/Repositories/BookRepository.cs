using Bookservice.WebAPI.Data;
using Bookservice.WebAPI.DTO;
using Bookservice.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookservice.WebAPI.Repositories
{
    public class BookRepository
    {
        private BookServiceContext bookServiceContext;

        public BookRepository(BookServiceContext context)
        {
            bookServiceContext = context;
        }

        public List<Book> List()
        {
            return bookServiceContext.Books.ToList();
        }

        public List<BookBasic> ListBasic()
        {
            return bookServiceContext.Books.Select(
                b => new BookBasic
                {
                    Id = b.Id,
                    Title = b.Title
                }).ToList();
        }
    }
}
