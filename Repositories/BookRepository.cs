using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Liberry_v2.Models.DTOs;
using Liberry_v2.Models.Entites;
using Liberry_v2.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Liberry_v2.Repositories{
    public class BookRepository : IBookRepository{

        private readonly AppDataContext _db;

        public BookRepository(AppDataContext db){
            _db = db;
        }

        public void AddBook(List<BookDTO> book)
        {
            foreach(BookDTO b in book){
                _db.Books.Add(new Book {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Published = b.Published,
                    ISBN = b.ISBN});
            }
            _db.SaveChanges();
            
        }

        public void AddLoan(List<LoanDTO> loans)
        {
            foreach(LoanDTO l in loans){
                _db.Loans.Add(new Loan {
                    BookId = l.BookId,
                    UserId = l.UserId,
                    DateOfLoan = l.DateOfLoan,
                    IsReturned = l.IsReturned
                });
            }
            _db.SaveChanges();
        }



        public BookDTO GetBookById(int id)
        {
            var book = (from b in _db.Books
                        where b.Id == id
                        select new BookDTO{
                            Id = b.Id,
                            Title = b.Title,
                            Author = b.Author,
                            Published = b.Published,
                            ISBN = b.ISBN
                        }).FirstOrDefault();
            return book;
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            var books = (from b in _db.Books
                            select new BookDTO{
                            Id = b.Id,
                            Title = b.Title,
                            Author = b.Author,
                            Published = b.Published,
                            ISBN = b.ISBN
                            }).ToList();

            return books;
        }

        public IEnumerable<LoanDTO> GetAllLoans()
        {
            var loans = (from l in _db.Loans
                            select new LoanDTO{
                                UserId = l.UserId,
                                BookId = l.BookId,
                                DateOfLoan = l.DateOfLoan,
                                IsReturned = l.IsReturned
                            }).ToList();

            return loans;
        }



        public void DeleteBook(int bookId)
        {
            Book book = (from b in _db.Books
                        where b.Id == bookId
                        select new Book{
                            Id = b.Id,
                            Title = b.Title,
                            Author = b.Author,
                            Published = b.Published,
                            ISBN = b.ISBN
                        }).FirstOrDefault();
            _db.Books.Remove(book);
        }

        public void UpdateBook(BookViewModel book, int bookId)
        {
            throw new NotImplementedException();
        }

        public void RemoveBookById(int book_id)
        {
            var bookToRemove = (from b in _db.Books
                                where b.Id == book_id
                                select b
                                ).SingleOrDefault();
            _db.Books.Remove(bookToRemove);
            _db.SaveChanges();
            
        }
    }
}