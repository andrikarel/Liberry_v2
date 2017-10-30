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
        public void AddUser(List<UserDTO> users)
        {
            foreach (UserDTO u in users)
            {
                _db.Users.Add(new User
                {
                    Id = u.Id,
                    Address = u.Address,
                    Email = u.Email,
                    Name = u.Name,
                    UserType = u.UserType
                });
            }
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
                                ).SingleOrDefault();
            _db.Users.Remove(userToRemove);
            _db.SaveChanges();

        }

        public void UpdateUser(UserDTO updatedUser)
        {
            User toUpdate = (from u in _db.Users
                            where u.Id == updatedUser.Id
                            select new User{
                                Id = updatedUser.Id,
                                Address = updatedUser.Address,
                                Email = updatedUser.Email,
                                Name = updatedUser.Name,
                                UserType = updatedUser.UserType
                            }).SingleOrDefault();
            if (toUpdate != null)
            {
                DeleteUser(toUpdate.Id);
                _db.Users.Add(toUpdate);
                _db.SaveChanges();
            }
        }

    }
}
