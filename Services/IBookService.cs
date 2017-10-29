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
        void AddBook(List<BookViewModel> book);
        void AddUser(List<UserViewModel> user);
        void DeleteBook(int book_id);
        void UpdateBook(BookViewModel book, int book_id);
    }
}