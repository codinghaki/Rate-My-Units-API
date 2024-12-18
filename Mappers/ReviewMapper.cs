using Rate_My_Units_API.Dtos;
using Rate_My_Units_API.Models;

namespace Rate_My_Units_API.Mappers;

public static class ReviewMapper
{
    public static ReviewDto ToDto(this Review review)
    {
        return new ReviewDto(
            review.Id,
            review.Content,
            review.Score,
            review.CreatedAt);
    }

    public static Review ToEntity(this CreateReviewDto createReviewDto, int unitId)
    {
        return new Review
        {
            UnitId = unitId,
            Content = createReviewDto.Content,
            Score = createReviewDto.Score,
        };
    }
}