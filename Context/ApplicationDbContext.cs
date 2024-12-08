using Microsoft.EntityFrameworkCore;
using Rate_My_Units_API.Models;

namespace Rate_My_Units_API.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }
    
    public DbSet<Unit> Units { get; set; }
    
    public DbSet<Review> Reviews { get; set; }
    
    public DbSet<ReviewRating> ReviewRatings { get; set; }
    
    public DbSet<ReviewHelpfulVote> ReviewHelpfulVotes { get; set; }
}