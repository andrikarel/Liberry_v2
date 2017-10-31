using System;
using System.Collections;
using System.Collections.Generic;
using Liberry_v2.Models.DTOs;
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
    }

}