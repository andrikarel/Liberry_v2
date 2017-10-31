using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Liberry_v2.Models.DTOs;
using Liberry_v2.Models.Entites;
using Liberry_v2.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Liberry_v2.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDataContext _db;

        public UserRepository(AppDataContext db)
        {
            _db = db;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = (from u in _db.Users
                         select new UserDTO
                         {
                             Id = u.Id,
                             Name = u.Name,
                             Email = u.Email,
                             Address = u.Address,
                             UserType = u.UserType
                         }).ToList();

            return users;

        }
        public void AddUser(UserViewModel u)
        {
            _db.Users.Add(new User
            {
                Address = u.Address,
                Email = u.Email,
                Name = u.Name,
                UserType = u.UserType
            });
        _db.SaveChanges();
        }

        public UserDTO GetUserById(int user_id)
        {
            var user = (from u in _db.Users
                        where u.Id == user_id
                        select new UserDTO
                        {
                            Id = u.Id,
                            Name = u.Name,
                            Address = u.Address,
                            Email = u.Email,
                            UserType = u.UserType
                        }).FirstOrDefault();
            return user;
        }

        public void DeleteUser(int user_id)
        {
            var userToRemove = (from u in _db.Users
                                where u.Id == user_id
                                select u
                                ).FirstOrDefault();
            _db.Users.Remove(userToRemove);
            _db.SaveChanges();

        }

        public void UpdateUser(UserViewModel updatedUser, int userId)
        {
            User toUpdate = (from u in _db.Users
                            where u.Id == userId
                            select u).FirstOrDefault();
            toUpdate.Name = updatedUser.Name;
            toUpdate.Address = updatedUser.Address;
            toUpdate.UserType = updatedUser.UserType;
            toUpdate.Email = updatedUser.Email;
            _db.SaveChanges();
        }

        public IEnumerable<LoanDTO> GetLoanedBooksByUser(int userId)
        {
            List<LoanDTO> loans = (from l in _db.Loans
                                    where l.UserId == userId
                                    select new LoanDTO{
                                        Id = l.Id,
                                        UserId = l.UserId,
                                        BookId = l.BookId,
                                        DateOfLoan = l.DateOfLoan
                                    }).ToList();
            return loans;
        }

        public void LoanBookToUser(DateTime loanDate, int user_id, int book_id)
        {
            _db.Loans.Add(new Loan{
                UserId = user_id,
                BookId = book_id,
                DateOfLoan = loanDate
            });
            _db.SaveChanges();
        }
    }
}
