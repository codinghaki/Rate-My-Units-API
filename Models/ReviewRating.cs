namespace Rate_My_Units_API.Models;

public class ReviewRating
{
    public int Id { get; set; }
    
    // Unit foreign key
    public int UnitId { get; set; }
    public Unit Unit { get; set; }
    
    // UnitReview foreign key
    public int ReviewId { get; set; }
    public Review Review { get; set; }
    
    public int Score;
}