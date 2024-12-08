namespace Rate_My_Units_API.Models;

public class ReviewRating
{
    public int Id { get; set; }
    
    // UnitReview foreign key
    public int ReviewId { get; set; }
    public Review Review { get; set; }
    
    public int Score;
}