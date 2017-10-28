using System;
using Liberry_v2.Models.ViewModels;
using Liberry_v2.Models.DTOs;
using System.Collections.Generic;
using System.Collections;


namespace Liberry_v2.Services
{
    public interface IBookService
    {
        bool AddBook(List<BookViewModel> book);
        bool AddUser(List<UserViewModel> user);
    }
}