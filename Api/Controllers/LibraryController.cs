using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liberry_v2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("")]
    public class LibraryController : Controller
    {
        // GET api/values
        [HttpGet]
        [Route("books")]
        public IActionResult GetAllBooks([FromQuery] DateTime LoanDate)
        {
            return Ok();
        }

        [HttpPost]
        [Route("books")]
        public IActionResult AddBook([FromBody] BookViewModel book)
        {
            return Ok();
        }

        [HttpGet]
        [Route("books/{book_id}")]
        public IActionResult GetBook(int book_id)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("books/{book_id}")]
        public IActionResult DeleteBook(int book_id)
        {
            return Ok();
        }

        [HttpPut]
        [Route("books/{book_id}")]
        public IActionResult UpdateBook([FromBody] BookViewModel book, int book_id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("users")]
        public IActionResult GetAllUsers([FromQuery] DateTime LoanDate, [FromQuery] int LoanDuration)
        {
            return Ok();
        }

        [HttpPost]
        [Route("users")]
        public IActionResult AddUser([FromBody] UserViewModel user)
        {
            return Ok();
        }

        [HttpGet]
        [Route("users/{user_id}")]
        public IActionResult GetUser(int user_id)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("users/{user_id}")]
        public IActionResult DeleteUser(int user_id)
        {
            return Ok();
        }

        [HttpPut]
        [Route("users/{user_id}")]
        public IActionResult UpdateUser([FromBody] UserViewModel user, int user_id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("users/{user_id}/books")]
        public IActionResult GetLoanedBooksByUser(int user_id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("users/{user_id}/books/{book_id}")]
        public IActionResult LoanBookToUser([FromBody] DateTime loanDate, int user_id, int book_id)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("users/{user_id}/books/{book_id}")]
        public IActionResult ReturnBookFromUser(int user_id, int book_id)
        {
            return Ok();
        }

        [HttpPut]
        [Route("users/{user_id}/books/{book_id}")]
        public IActionResult UpdateLoanByUser([FromBody] DateTime loanDate, int user_id, int book_id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("users/{user_id}/reviews")]
        public IActionResult GetReviewsByUser(int user_id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("books/{book_id}/reviews/{user_id}")]
        [Route("users/{user_id}/reviews/{book_id}")]
        public IActionResult GetReview(int user_id, int book_id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("books/{book_id}/reviews/{user_id}")]
        [Route("users/{user_id}/reviews/{book_id}")]
        public IActionResult AddReview([FromBody] int rating, int user_id, int book_id)
        {
            return Ok();
        }
        
        [HttpDelete]
        [Route("books/{book_id}/reviews/{user_id}")]
        [Route("users/{user_id}/reviews/{book_id}")]
        public IActionResult DeleteReview(int user_id, int book_id)
        {
            return Ok();
        }

        [HttpPut]
        [Route("books/{book_id}/reviews/{user_id}")]
        [Route("users/{user_id}/reviews/{book_id}")]
        public IActionResult UpdateReview([FromBody] int rating, int user_id, int book_id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("users/{user_id}/recommendation")]
        public IActionResult GetRecommendations(int user_id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("books/reviews")]
        public IActionResult GetAllReviews()
        {
            return Ok();
        }

        [HttpGet]
        [Route("books/{book_id}/reviews")]
        public IActionResult GetReviewsForBook(int book_id)
        {
            return Ok();
        }
    }
}
