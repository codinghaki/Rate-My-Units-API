using Rate_My_Units_API.Dtos;
using Rate_My_Units_API.Models;

namespace Rate_My_Units_API.Interfaces;

public interface IReviewService
{
    Task<List<ReviewDto?>> GetReviewsByUnitIdAsync(int unitId);
    
    Task<ReviewDto> CreateReviewAsync(Review review);
}