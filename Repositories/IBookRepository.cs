using System.Collections;
using System.Collections.Generic;
using Liberry_v2.Models.DTOs;
using Liberry_v2.Models.ViewModels;

namespace Liberry_v2.Repositories{
    public interface IBookRepository
    {
        IEnumerable<BookDTO> GetAllBooks();
        IEnumerable<UserDTO> GetAllUsers();
        IEnumerable<LoanDTO> GetAllLoans();
        BookDTO GetBookById(int id);
        void AddBook(List<BookDTO> bookDTO);
        void AddUser(List<UserDTO> users);
        void AddLoan(List<LoanDTO> loans);
        void DeleteBook(int bookId);
        void UpdateBook(BookViewModel book, int bookId);
    }
}