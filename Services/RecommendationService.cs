using System.Collections.Generic;
using Liberry_v2.Models.DTOs;
using Liberry_v2.Repositories;

namespace Liberry_v2.Services
{
    public class RecommendationService : IRecommendationService
    {
        ILoanService _loanService;
        IBookService _bookService;
        IUserRepository _repo;

        public RecommendationService(IUserRepository repo, ILoanService loanService, IBookService bookService)
        {
            _repo = repo;
            _loanService = loanService;
            _bookService = bookService;
        }
        public IEnumerable<BookDTO> GetRecommendations(int user_id)
        {
            List<BookDTO> books = new List<BookDTO>();
            IEnumerable<LoanDTO> usersLoans = _loanService.GetLoanedBooksByUser(user_id);
            IEnumerable<BookDTO> allBooks = _bookService.GetAllBooks();
            foreach(BookDTO book in allBooks){
                if(HasRead(user_id, book.Id)){
                    continue;
                }
                bool hasReadBySameAuthor = false;
                foreach(LoanDTO loanedBook in usersLoans){
                    BookDTO actualBook = _bookService.GetBookById(loanedBook.BookId);
                    if(actualBook.Author == book.Author){
                        hasReadBySameAuthor = true;
                    }
                }
                if(hasReadBySameAuthor){
                    books.Add(book);
                }
            }

            return books;
        }

        public bool HasRead(int user_id, int book_id){
            LoanDTO loan = _repo.GetLoan(user_id, book_id);
            if(loan == null){
                return false;
            }
            return true;
        }
    }
}