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
        void AddUser(List<UserViewModel> user);
        UserDTO GetUserByID(int user_id);
        void DeleteUser(int user_id);
        void UpdateUser(UserViewModel user, int user_id);
    }
}