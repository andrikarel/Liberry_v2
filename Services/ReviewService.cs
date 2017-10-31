using System.Collections.Generic;
using Liberry_v2.Models.DTOs;
using Liberry_v2.Models.Entites;
using Liberry_v2.Models.ViewModels;
using Liberry_v2.Repositories;
using Liberry_v2.Services.Exceptions;

namespace Liberry_v2.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUserRepository _repo;
        private readonly IUserService _userService;
        private readonly IBookService _bookService;

        public ReviewService(IUserRepository repo, IUserService userService, IBookService bookService)
        {
            _repo = repo;
            _userService = userService;
            _bookService = bookService;
        }

        public void AddReview(ReviewViewModel review, int user_id, int book_id)
        {
            UserDTO user = _userService.GetUserByID(user_id);
            BookDTO book = _bookService.GetBookById(book_id);
            if(user == null){
                throw new NotFoundException("User Id not found");
            }
            if(book == null){
                throw new NotFoundException("Book Id not found");
            }
            _repo.AddReview(review, user_id, book_id);
        }

        public void DeleteReview(int user_id, int book_id)
        {
            UserDTO user = _userService.GetUserByID(user_id);
            BookDTO book = _bookService.GetBookById(book_id);
            if(user == null){
                throw new NotFoundException("User Id not found");
            }
            if(book == null){
                throw new NotFoundException("Book Id not found");
            }
            _repo.DeleteReview(user_id, book_id);
        }

        public IEnumerable<ReviewDTO> GetAllReviews()
        {
            return _repo.GetAllReviews();
        }

        public ReviewDTO GetReview(int user_id, int book_id)
        {
            UserDTO user = _userService.GetUserByID(user_id);
            BookDTO book = _bookService.GetBookById(book_id);
            if(user == null){
                throw new NotFoundException("User Id not found");
            }
            if(book == null){
                throw new NotFoundException("Book Id not found");
            }
            return _repo.GetReview(user_id, book_id);
        }

        public IEnumerable<ReviewDTO> GetReviewsByUser(int user_id)
        {
            UserDTO user = _userService.GetUserByID(user_id);
            if(user == null){
                throw new NotFoundException("Id not found");
            }
            return _repo.GetReviewsByUser(user_id);
        }

        public IEnumerable<ReviewDTO> GetReviewsForBook(int book_id)
        {
            BookDTO book = _bookService.GetBookById(book_id);
            if(book == null){
                throw new NotFoundException("Id not found");
            }
            return _repo.GetReviewsForBook(book_id);
        }

        public void UpdateReview(ReviewViewModel review, int user_id, int book_id)
        {
            UserDTO user = _userService.GetUserByID(user_id);
            BookDTO book = _bookService.GetBookById(book_id);
            if(user == null){
                throw new NotFoundException("User Id not found");
            }
            if(book == null){
                throw new NotFoundException("Book Id not found");
            }
            _repo.UpdateReview(review, user_id, book_id);        
        }
    }
}