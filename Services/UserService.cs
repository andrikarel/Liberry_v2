using System;
using System.Collections.Generic;
using Liberry_v2.Models.DTOs;
using Liberry_v2.Models.ViewModels;
using Liberry_v2.Repositories;
using Liberry_v2.Services.Exceptions;

namespace Liberry_v2.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public void AddUser(UserViewModel user)
        {
            _repo.AddUser(user);
        }

        public void DeleteUser(int user_id)
        {
            _repo.DeleteUser(user_id);
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return _repo.GetAllUsers();
        }

        public IEnumerable<LoanDTO> GetLoanedBooksByUser(int user_id)
        {
            UserDTO user = GetUserByID(user_id);
            if(user == null){
                throw new NotFoundException("Id not found");
            }
            return _repo.GetLoanedBooksByUser(user_id);
        }

        public UserDTO GetUserByID(int user_id)
        {
            return _repo.GetUserById(user_id);
        }

        public void LoanBookToUser(DateTime loanDate, int user_id, int book_id)
        {
            UserDTO user = GetUserByID(user_id);
            //Same for book
            //move to loanservice so we can check shit for both
            _repo.LoanBookToUser(loanDate, user_id, book_id);
        }

        public void UpdateUser(UserViewModel user,int user_id)
        {
            UserDTO u = GetUserByID(user_id);
            if(u == null){
                throw new NotFoundException("Id not found");
            }
            _repo.UpdateUser(user, user_id);
                

        }
    }
}