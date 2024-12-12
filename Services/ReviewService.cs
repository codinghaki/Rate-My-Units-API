using Microsoft.EntityFrameworkCore;
using Rate_My_Units_API.Context;
using Rate_My_Units_API.Dtos;
using Rate_My_Units_API.Interfaces;
using Rate_My_Units_API.Mappers;
using Rate_My_Units_API.Models;

namespace Rate_My_Units_API.Services;

public class ReviewService : IReviewService
{
    private readonly ApplicationDbContext _context;

    public ReviewService(ApplicationDbContext context)
    {
        this._context = context;
    }

    public async Task<List<ReviewDto?>> GetReviewsByUnitIdAsync(int unitId)
    {
        var unitReviews = await _context.Reviews
            .Where(review => review.UnitId == unitId)
            .ToListAsync();

        var unitReviewsDtos = unitReviews.Select(review => review.ToDto()).ToList();
        
        return unitReviewsDtos;
    }

    public async Task<ReviewDto> CreateReviewAsync(Review review)
    {
        await _context.Reviews.AddAsync(review);
        
        await _context.SaveChangesAsync();
        
        return review.ToDto();
    }
}