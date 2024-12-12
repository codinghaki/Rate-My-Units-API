namespace Rate_My_Units_API.Dtos;

public record CreateReviewDto(
    string Content,
    int Score
    );