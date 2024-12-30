using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rate_My_Units_API.Context;
using Rate_My_Units_API.Helpers;
using Rate_My_Units_API.Interfaces;
using Rate_My_Units_API.Mappers;

namespace Rate_My_Units_API.Controllers;

[Route("api/units")]
[ApiController]
public class UnitController : ControllerBase
{
    private readonly IUnitService _unitService;
    
    public UnitController(IUnitService unitService)
    {
        this._unitService = unitService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUnits([FromQuery] UnitQueryObject unitQueryObject)
    {
        var result = await _unitService.GetAllUnitsAsync(unitQueryObject);
        
        return Ok(result);
    }

    [HttpGet("{unitId:int}")]
    public async Task<IActionResult> GetUnitById([FromRoute]int unitId)
    {
        var result = await _unitService.GetUnitByIdAsync(unitId);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
    
}