namespace Rate_My_Units_API.Models;

public class Review
{
    public int Id { get; set; }
    
    // Unit foreign key
    public int UnitId { get; set; }
    public Unit Unit { get; set; }
    
    public string Content { get; set; }
    
    public int Score { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}