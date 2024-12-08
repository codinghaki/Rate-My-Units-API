namespace Rate_My_Units_API.Models;

public class Unit
{
    public int Id { get; set; }
    
    public string Code { get; set; }
    
    public string Name { get; set; }
    
    // Outgoing relationships
    public List<Review> Reviews { get; set; }
}