using System.Collections.Generic;
using Liberry_v2.Models.DTOs;

namespace Liberry_v2.Services
{
    public interface IRecommendationService
    {
        IEnumerable<BookDTO> GetRecommendations(int user_id);
    }
}