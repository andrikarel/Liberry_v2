using System;
using System.Collections.Generic;
using Liberry_v2.Models.DTOs;
using Liberry_v2.Models.ViewModels;
using Liberry_v2.Repositories;

namespace Liberry_v2.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public void AddUser(List<UserViewModel> user)
        {
            List<UserDTO> users = new List<UserDTO>();
            foreach (UserViewModel u in user)
            {
                users.Add(new UserDTO
                {
                    Id = u.Id,
                    Name = u.FirstName + ", " + u.LastName,
                    Address = u.Address,
                    Email = u.Email,
                    UserType = "NormalUser"

                });
                _repo.AddUser(users);
            }

        }

        public void DeleteUser(int user_id)
        {
            _repo.DeleteUser(user_id);
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return _repo.GetAllUsers();
        }

        public UserDTO GetUserByID(int user_id)
        {
            return _repo.GetUserById(user_id);
        }

        public void UpdateUser(UserViewModel user,int user_id)
        {
            UserDTO updatedUser = new UserDTO{
                Id = user_id,
                Name = user.FirstName + ", " + user.LastName,
                Address = user.Address,
                Email = user.Email,
                UserType = "NormalUser"

            };
            _repo.UpdateUser(updatedUser);
                

        }
    }
}