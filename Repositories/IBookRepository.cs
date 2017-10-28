using System.Collections;
using System.Collections.Generic;
using Liberry_v2.Models.DTOs;

namespace Liberry_v2.Repositories{
    public interface IBookRepository
    {
        bool addBook(List<BookDTO> bookDTO);
    }
}