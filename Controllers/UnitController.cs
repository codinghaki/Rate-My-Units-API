using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rate_My_Units_API.Context;
using Rate_My_Units_API.Mappers;

namespace Rate_My_Units_API.Controllers;

[Route("api/unit")]
[ApiController]
public class UnitController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    
    public UnitController(ApplicationDbContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUnits()
    {
        var units = await _context.Units.ToListAsync();
        
        var unitsDtos = units.Select(unit => unit.ToDto());
        
        return Ok(unitsDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUnitById([FromRoute]int id)
    {
        var unit = await _context.Units.FirstOrDefaultAsync(unit => unit.Id == id);

        return Ok(unit.ToDto());
    }
    
}