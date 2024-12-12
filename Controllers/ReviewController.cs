using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Rate_My_Units_API.Dtos;
using Rate_My_Units_API.Interfaces;
using Rate_My_Units_API.Mappers;
using Rate_My_Units_API.Services;

namespace Rate_My_Units_API.Controllers;

[Route("api/reviews")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;
    private readonly IUnitService _unitService;

    public ReviewController(IReviewService reviewService, IUnitService unitService)
    {
        this._reviewService = reviewService;
        this._unitService = unitService;
    }

    [HttpGet("{unitId:int}")]
    public async Task<IActionResult> GetReviewsByUnitId([FromRoute]int unitId)
    {
        var result = await _reviewService.GetReviewsByUnitIdAsync(unitId);

        if (result.IsNullOrEmpty() )
        {
            return NotFound();
        }
        
        return Ok(result);
    }

    [HttpPost("{unitId:int}")]
    public async Task<IActionResult> CreateReview([FromRoute] int unitId, CreateReviewDto createReviewDto)
    {
        if (!await _unitService.UnitExistsAsync(unitId))
        {
            return BadRequest("Unit not found.");
        }

        var reviewModel = createReviewDto.ToEntity(unitId);

        await _reviewService.CreateReviewAsync(reviewModel);
        
        return CreatedAtAction(nameof(GetReviewsByUnitId), new { unitId = unitId }, reviewModel.ToDto());
    }

    [HttpDelete("{reviewId:int}")]
    public async Task<IActionResult> DeleteReview([FromRoute] int reviewId)
    {
        var result = await _reviewService.DeleteReviewAsync(reviewId);

        if (result == null)
        {
            return NotFound();
        }
        
        return Ok(result);
    }
    
}