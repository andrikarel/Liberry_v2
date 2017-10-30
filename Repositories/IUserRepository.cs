using System.Collections;
using System.Collections.Generic;
using Liberry_v2.Models.DTOs;
using Liberry_v2.Models.ViewModels;

namespace Liberry_v2.Repositories{
    public interface IUserRepository
    {
        IEnumerable<UserDTO> GetAllUsers();
        void AddUser(List<UserDTO> users);
        UserDTO GetUserById(int user_id);
        void DeleteUser(int user_id);
        void UpdateUser(UserDTO updatedUser);
    }

}