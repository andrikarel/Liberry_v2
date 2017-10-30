

using System;
using System.Collections;
using System.Collections.Generic;
using Liberry_v2.Models.DTOs;
using Liberry_v2.Models.ViewModels;
using Liberry_v2.Repositories;
using Liberry_v2.Services.Exceptions;

namespace Liberry_v2.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;

        public BookService(IBookRepository repo){
            _repo = repo;
        }

        public void AddBook(List<BookViewModel> book)
        {
            List<BookDTO> toAdd = new List<BookDTO>();
            foreach(BookViewModel b in book){
                toAdd.Add(new BookDTO{
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.AuthorFirstName + ", " + b.AuthorLastName,
                    Published = b.PublishDate,
                    ISBN = b.ISBN
                });
            }
            _repo.AddBook(toAdd);
        }


        public IEnumerable<BookDTO> GetAllBooks()
        {
            return _repo.GetAllBooks();
        }

        public IEnumerable<BookDTO> GetBooksInLoanOnDate(DateTime loanDate)
        {
            IEnumerable<BookDTO> allBooks = _repo.GetAllBooks();
            IEnumerable<LoanDTO> allLoans = _repo.GetAllLoans();
            List<BookDTO> selectBooks = new List<BookDTO>();
            foreach(BookDTO b in allBooks){
                foreach(LoanDTO l in allLoans){
                    if(l.IsReturned == 0 && l.BookId == b.Id && (l.DateOfLoan.CompareTo(loanDate) < 0)){
                        selectBooks.Add(b);
                    }
                }
            }
            return selectBooks;
        }

        public BookDTO GetBookById(int id){
            BookDTO book = _repo.GetBookById(id);
            if(book == null){
                throw new NotFoundException("Id not found");
            }
            return book;
        }

        public void DeleteBook(int book_id)
        {
            _repo.RemoveBookById(book_id);
        }

        public void UpdateBook(BookViewModel book, int book_id)
        {
            throw new NotImplementedException();
        }
    }
}
