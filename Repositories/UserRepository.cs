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
                                        DateOfLoan = l.DateOfLoan,
                                        IsReturned = l.IsReturned
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

        public void ReturnBookFromUser(int user_id, int book_id)
        {
            Loan loan = (from l in _db.Loans
                        where l.UserId == user_id
                        && l.BookId == book_id
                        select l).FirstOrDefault();
            loan.IsReturned = true;
            _db.SaveChanges();
        }

        public void UpdateLoanByUser(LoanViewModel updatedLoan, int user_id, int book_id)
        {
            Loan loan = (from l in _db.Loans
                        where l.UserId == user_id
                        && l.BookId == book_id
                        select l).FirstOrDefault();
            loan.DateOfLoan = updatedLoan.DateOfLoan;
            _db.SaveChanges();
        }

        public IEnumerable<ReviewDTO> GetReviewsByUser(int user_id)
        {
            List<ReviewDTO> reviews = (from r in _db.Reviews
                                            where r.UserId == user_id
                                            select new ReviewDTO{
                                                ID = r.ID,
                                                BookId = r.BookId,
                                                UserId = r.UserId,
                                                DateWritten = r.DateWritten,
                                                Rating = r.Rating
                                            }).ToList();
            return reviews;
        }

        public ReviewDTO GetReview(int user_id, int book_id)
        {
            ReviewDTO review = (from r in _db.Reviews
                                where r.UserId == user_id
                                && r.BookId == user_id
                                select new ReviewDTO{
                                    ID = r.ID,
                                    BookId = r.BookId,
                                    UserId = r.UserId,
                                    DateWritten = r.DateWritten,
                                    Rating = r.Rating
                                }).FirstOrDefault();
            return review;
        }

        public void AddReview(ReviewViewModel review, int user_id, int book_id)
        {
            _db.Reviews.Add(new Review{
                UserId = user_id,
                BookId = book_id,
                DateWritten = review.DateWritten,
                Rating = review.Rating
            });
            _db.SaveChanges();
        }

        public void DeleteReview(int user_id, int book_id)
        {
            var reviewToRemove = (from r in _db.Reviews
                                where r.UserId == user_id
                                && r.BookId == book_id
                                select r
                                ).FirstOrDefault();
            _db.Reviews.Remove(reviewToRemove);
            _db.SaveChanges();

        }

        public void UpdateReview(ReviewViewModel review, int user_id, int book_id)
        {
            Review toUpdate = (from r in _db.Reviews
                            where r.UserId == user_id
                            && r.BookId == book_id
                            select r).FirstOrDefault();
            toUpdate.DateWritten = review.DateWritten;
            toUpdate.Rating = review.Rating;
            _db.SaveChanges();
        }

        public IEnumerable<ReviewDTO> GetAllReviews()
        {
            IEnumerable<ReviewDTO> reviews = (from r in _db.Reviews
                                                select new ReviewDTO{
                                                    ID = r.ID,
                                                    UserId = r.UserId,
                                                    BookId = r.BookId,
                                                    DateWritten = r.DateWritten,
                                                    Rating = r.Rating
                                                }).ToList();
            return reviews;
                
        }

        public IEnumerable<ReviewDTO> GetReviewsForBook(int book_id)
        {
            List<ReviewDTO> reviews = (from r in _db.Reviews
                                            where r.BookId == book_id
                                            select new ReviewDTO{
                                                ID = r.ID,
                                                BookId = r.BookId,
                                                UserId = r.UserId,
                                                DateWritten = r.DateWritten,
                                                Rating = r.Rating
                                            }).ToList();
            return reviews;
        }

        public LoanDTO GetLoan(int user_id, int book_id)
        {
            LoanDTO loan = (from l in _db.Loans
                                where l.UserId == user_id
                                && l.BookId == user_id
                                select new LoanDTO{
                                    Id = l.Id,
                                    BookId = l.BookId,
                                    UserId = l.UserId,
                                    DateOfLoan = l.DateOfLoan,
                                    IsReturned = l.IsReturned
                                }).FirstOrDefault();
            return loan;
        }
    }
}
