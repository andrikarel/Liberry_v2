using System;
using Liberry_v2.Models.ViewModels;
using Liberry_v2.Models.DTOs;
using System.Collections.Generic;
using System.Collections;


namespace Liberry_v2.Services
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetAllBooks();
        IEnumerable<BookDTO> GetBooksInLoanOnDate(DateTime loanDate);
        BookDTO GetBookById(int id);
        void AddBook(BookViewModel book);
        void DeleteBook(int bookId);
        void UpdateBook(BookViewModel book, int bookId);
    }
}