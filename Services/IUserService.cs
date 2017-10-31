using System.Collections.Generic;
using System.Collections;
using Liberry_v2.Models.DTOs;
using Liberry_v2.Models.ViewModels;
using System;

namespace Liberry_v2.Services
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUsers();
        void AddUser(UserViewModel user);
        UserDTO GetUserByID(int user_id);
        void DeleteUser(int user_id);
        void UpdateUser(UserViewModel user, int user_id);
        IEnumerable<LoanDTO> GetLoanedBooksByUser(int user_id);
        void LoanBookToUser(DateTime loanDate, int user_id, int book_id);
    }
}