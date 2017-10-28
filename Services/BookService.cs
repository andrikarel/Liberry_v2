

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
            return _repo.addBook(toAdd);
        }
        public bool AddUser(List<UserViewModel> user){
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
            bool userAdded = _repo.addUser(users);
            
            bool loanAdded = _repo.addLoan(loans);
            
            if(userAdded && loanAdded){
                return true;
            }
            else{
                return false;
            }
            

        }
    }
}
