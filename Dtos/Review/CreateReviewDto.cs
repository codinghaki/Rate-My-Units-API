using System.ComponentModel.DataAnnotations;

namespace Rate_My_Units_API.Dtos;

public record CreateReviewDto(
    [Required]
    [MinLength(5, ErrorMessage = "Content must be at least 5 characters")]
    [MaxLength(1000, ErrorMessage = "Content cannot exceed 1000 characters")]
    string Content,
    [Required]
    [Range(1, 10, ErrorMessage = "Score must be between 1 and 10")]
    int Score
    );