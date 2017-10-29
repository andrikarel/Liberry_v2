

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
                    Id = b.bok_id,
                    Title = b.bok_titill,
                    Author = b.fornafn_hofundar + ", " + b.eftirnafn_hofundar,
                    Published = b.utgafudagur,
                    ISBN = b.ISBN
                });
            }
            _repo.AddBook(toAdd);
        }
        public void AddUser(List<UserViewModel> user){
            List<UserDTO> users = new List<UserDTO>();
            List<LoanDTO> loans = new List<LoanDTO>();
            foreach(UserViewModel u in user){
                users.Add(new UserDTO{
                    Id = u.vinur_id,
                    Name = u.fornafn + ", " + u.eftirnafn,
                    Address = u.heimilisfang,
                    Email = u.netfang,
                    UserType = "NormalUser"
                    
                });
                Console.Write(u.lanasafn);
                if(u.lanasafn != null){
                    foreach(LoanViewModel l in u.lanasafn){
                        loans.Add(new LoanDTO{
                            BookId = l.bok_id,
                            UserId = u.vinur_id,
                            DateOfLoan = l.bok_lanadagsetning
                        });
                    }
                }
            }
            _repo.AddUser(users);
            _repo.AddLoan(loans);
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

        public BookDTO GetBookById(int id){
            BookDTO book = _repo.GetBookById(id);
            if(book == null){
                throw new NotFoundException("Id not found");
            }
            return book;
        }

    }
}
