

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

        public void AddBook(BookViewModel book)
        {
            _repo.AddBook(book);
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
                    if(!l.IsReturned && l.BookId == b.Id && (l.DateOfLoan.CompareTo(loanDate) < 0)){
                        selectBooks.Add(b);
                    }
                }
            }
            return selectBooks;
        }

        public BookDTO GetBookById(int bookId){
            BookDTO book = _repo.GetBookById(bookId);
            if(book == null){
                throw new NotFoundException("Id not found");
            }
            return book;
        }

        public void DeleteBook(int bookId){

            // Throws not found if the id doesn't exist
            BookDTO book = GetBookById(bookId);

            _repo.DeleteBook(bookId);
        }

        public void UpdateBook(BookViewModel book, int bookId)
        {

            // Throws not found if the id doesn't exist
            BookDTO b = GetBookById(bookId);

            _repo.UpdateBook(book, bookId);
        }
    }
}
