

using System;
using System.Collections;
using System.Collections.Generic;
using Liberry_v2.Models.DTOs;
using Liberry_v2.Models.ViewModels;
using Liberry_v2.Repositories;

namespace Liberry_v2.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;

        public BookService(IBookRepository repo){
            _repo = repo;
        }

        public bool AddBook(List<BookViewModel> book)
        {
            /*
            return _repo.addBook( new BookDTO{
                Id = book.bok_id,
                Title = book.bok_titill,
                Author = book.fornafn_hofundar + ", " + book.eftirnafn_hofundar,
                Published = book.utgafudagur,
                ISBN = book.ISBN
            });
            */
            List<BookDTO> toParse = new List<BookDTO>();
            foreach(BookViewModel b in book){
                toParse.Add(new BookDTO{
                    Id = b.bok_id,
                    Title = b.bok_titill,
                    Author = b.fornafn_hofundar + ", " + b.eftirnafn_hofundar,
                    Published = b.utgafudagur,
                    ISBN = b.ISBN
                });
            }
            return _repo.addBook(toParse);
        }
    }
}
