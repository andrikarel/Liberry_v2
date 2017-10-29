using System;
using System.Collections;
using System.Collections.Generic;
using Liberry_v2.Models.DTOs;
using Liberry_v2.Models.ViewModels;
using Liberry_v2.Services;
using Liberry_v2.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("")]
    public class LibraryController : Controller
    {
        private readonly IBookService _bookService;
        public LibraryController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET api/values
        [HttpGet]
        [Route("books")]
        public IActionResult GetAllBooks([FromQuery] DateTime LoanDate)
        {
            IEnumerable<BookDTO> books;

            if(LoanDate == null){
                books = _bookService.GetAllBooks();
            }else{
                books = _bookService.GetBooksInLoanOnDate(LoanDate);
            }
            return Ok(books);
        }

        [HttpPost]
        [Route("books")]
        public IActionResult AddBook([FromBody] List<BookViewModel> book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return StatusCode(412);
            }
            try{
                _bookService.AddBook(book);
            }catch(DbUpdateException e){
                return StatusCode(503);
            }

            return StatusCode(201);
        }


        [HttpGet]
        [Route("books/{book_id}")]
        public IActionResult GetBook(int book_id)
        {
            BookDTO book;
            try{
                book = _bookService.GetBookById(book_id);
            }catch(NotFoundException e){
                return NotFound();
            }
            return Ok(book);
        }

        [HttpDelete]
        [Route("books/{book_id}")]
        public IActionResult DeleteBook(int book_id)
        {
            try{
                _bookService.DeleteBook(book_id);
            }catch(NotFoundException e){
                return NotFound();
            }catch(DbUpdateException e){
                return StatusCode(503);
            }
            return StatusCode(204);
        }

        [HttpPut]
        [Route("books/{book_id}")]
        public IActionResult UpdateBook([FromBody] BookViewModel book, int book_id)
        {
            if (book == null || book_id == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return StatusCode(412);
            }
            try{
                _bookService.UpdateBook(book, book_id);
            }catch(DbUpdateException e){
                return StatusCode(412);
            }catch(NotFoundException e){
                return NotFound();
            }

            return StatusCode(201);
        }

        [HttpGet]
        [Route("users")]
        public IActionResult GetAllUsers([FromQuery] DateTime LoanDate, [FromQuery] int LoanDuration)
        {
            return Ok();
        }

        [HttpPost]
        [Route("users")]
        public IActionResult AddUser([FromBody] List<UserViewModel> user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {

                return StatusCode(412);
            }
            try
            {
                _bookService.AddUser(user);
            }
            catch (DbUpdateException e)
            {
                return StatusCode(412);
            }

            return StatusCode(201);
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
