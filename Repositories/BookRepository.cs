using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Liberry_v2.Models.DTOs;
using Liberry_v2.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace Liberry_v2.Repositories{
    public class BookRepository : IBookRepository{

        private readonly AppDataContext _db;

        public BookRepository(AppDataContext db){
            _db = db;
        }

        public bool addBook(List<BookDTO> book)
        {
            foreach(BookDTO b in book){
                _db.Books.Add(new Book {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Published = b.Published,
                    ISBN = b.ISBN});
            }

            try{
                _db.SaveChanges();
            }catch(DbUpdateException e){
                return false;
            }
            return true;
        }

    }
}