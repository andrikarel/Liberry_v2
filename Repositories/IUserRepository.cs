using System;
using System.Collections;
using System.Collections.Generic;
using Liberry_v2.Models.DTOs;
using Liberry_v2.Models.Entites;
using Liberry_v2.Models.ViewModels;

namespace Liberry_v2.Repositories{
    public interface IUserRepository
    {
        IEnumerable<UserDTO> GetAllUsers();
        void AddUser(UserViewModel user);
        UserDTO GetUserById(int user_id);
        void DeleteUser(int user_id);
        void UpdateUser(UserViewModel updatedUser, int userId);
        IEnumerable<LoanDTO> GetLoanedBooksByUser(int userId);
        void LoanBookToUser(DateTime loanDate, int user_id, int book_id);
        void ReturnBookFromUser(int user_id, int book_id);
        void UpdateLoanByUser(LoanViewModel loan, int user_id, int book_id);
        IEnumerable<ReviewDTO> GetReviewsByUser(int user_id);
        ReviewDTO GetReview(int user_id, int book_id);
        void AddReview(ReviewViewModel review, int user_id, int book_id);
        void DeleteReview(int user_id, int book_id);
        void UpdateReview(ReviewViewModel review, int user_id, int book_id);
        IEnumerable<ReviewDTO> GetAllReviews();
        IEnumerable<ReviewDTO> GetReviewsForBook(int book_id);
        LoanDTO GetLoan(int user_id, int book_id);
    }

}