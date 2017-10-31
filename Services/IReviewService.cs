using System.Collections.Generic;
using Liberry_v2.Models.Entites;
using Liberry_v2.Models.ViewModels;

namespace Liberry_v2.Services
{
    public interface IReviewService
    {
        IEnumerable<ReviewDTO> GetReviewsByUser(int user_id);
        ReviewDTO GetReview(int user_id, int book_id);
        void AddReview(ReviewViewModel review, int user_id, int book_id);
        void DeleteReview(int user_id, int book_id);
        void UpdateReview(ReviewViewModel review, int user_id, int book_id);
        IEnumerable<ReviewDTO> GetAllReviews();
        IEnumerable<ReviewDTO> GetReviewsForBook(int book_id);
    }
}