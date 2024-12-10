using Microsoft.AspNetCore.Mvc;
using Rate_My_Units_API.Context;

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
    public IActionResult GetAllUnits()
    {
        var units = _context.Units.ToList();
        
        return Ok(units);
    }

    [HttpGet("{id}")]
    public IActionResult GetUnitById([FromRoute]int id)
    {
        var unit = _context.Units.FirstOrDefault(unit => unit.Id == id);

        return Ok(unit);
    }
    
}