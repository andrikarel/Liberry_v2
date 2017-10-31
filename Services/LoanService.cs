using System;
using System.Collections.Generic;
using Liberry_v2.Models.DTOs;
using Liberry_v2.Models.Entites;
using Liberry_v2.Models.ViewModels;
using Liberry_v2.Repositories;
using Liberry_v2.Services.Exceptions;

namespace Liberry_v2.Services
{
    public class LoanService : ILoanService
    {
        private readonly IUserRepository _repo;
        private readonly IUserService _userService;
        private readonly IBookService _bookService;

        public LoanService(IUserRepository repo, IUserService userService, IBookService bookService)
        {
            _repo = repo;
            _userService = userService;
            _bookService = bookService;
        }

        public IEnumerable<LoanDTO> GetLoanedBooksByUser(int user_id)
        {
            UserDTO user = _userService.GetUserByID(user_id);
            if(user == null){
                throw new NotFoundException("User Id not found");
            }
            return _repo.GetLoanedBooksByUser(user_id);
        }

        public void LoanBookToUser(DateTime loanDate, int user_id, int book_id)
        {
            UserDTO user = _userService.GetUserByID(user_id);
            BookDTO book = _bookService.GetBookById(book_id);
            if(user == null){
                throw new NotFoundException("User Id not found");
            }
            if(book == null){
                throw new NotFoundException("Book Id not found");
            }
            _repo.LoanBookToUser(loanDate, user_id, book_id);
        }

        public void ReturnBookFromUser(int user_id, int book_id)
        {
            UserDTO user = _userService.GetUserByID(user_id);
            BookDTO book = _bookService.GetBookById(book_id);
            if(user == null){
                throw new NotFoundException("User Id not found");
            }
            if(book == null){
                throw new NotFoundException("Book Id not found");
            }
            _repo.ReturnBookFromUser(user_id, book_id);
        }

        public void UpdateLoanByUser(LoanViewModel loan, int user_id, int book_id)
        {
            UserDTO user = _userService.GetUserByID(user_id);
            BookDTO book = _bookService.GetBookById(book_id);
            if(user == null){
                throw new NotFoundException("User Id not found");
            }
            if(book == null){
                throw new NotFoundException("Book Id not found");
            }
            _repo.UpdateLoanByUser(loan, user_id, book_id);
        }
    }
}