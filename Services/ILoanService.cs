using System;
using System.Collections.Generic;
using Liberry_v2.Models.DTOs;
using Liberry_v2.Models.ViewModels;

namespace Liberry_v2.Services
{
    public interface ILoanService
    {

        IEnumerable<LoanDTO> GetLoanedBooksByUser(int user_id);
        void LoanBookToUser(DateTime loanDate, int user_id, int book_id);
        void ReturnBookFromUser(int user_id, int book_id);
        void UpdateLoanByUser(LoanViewModel loan, int user_id, int book_id);
    }
}