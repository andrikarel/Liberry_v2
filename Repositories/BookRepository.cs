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

        public bool addLoan(List<LoanDTO> loans)
        {
            foreach(LoanDTO l in loans){
                _db.Loans.Add(new Loan {
                    BookId = l.BookId,
                    UserId = l.UserId,
                    DateOfLoan = l.DateOfLoan
                });
            }

            try{
                _db.SaveChanges();
            }catch(DbUpdateException e){
                return false;
            }
            return true;
        }

        public bool addUser(List<UserDTO> users)
        {
            foreach(UserDTO u in users){
                _db.Users.Add(new User {
                    Id = u.Id,
                    Address = u.Address,
                    Email = u.Email,
                    Name = u.Name,
                    UserType = u.UserType
                    });
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