using Microsoft.EntityFrameworkCore;
using Rate_My_Units_API.Context;
using Rate_My_Units_API.Dtos.Unit;
using Rate_My_Units_API.Interfaces;
using Rate_My_Units_API.Mappers;
using Rate_My_Units_API.Models;

namespace Rate_My_Units_API.Services;

public class UnitService : IUnitService
{
    private readonly ApplicationDbContext _context;

    public UnitService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<UnitDto>> GetAllUnitsAsync()
    {
        var units = await _context.Units.ToListAsync();
        
        var unitsDtos = units.Select(unit => unit.ToDto());
        
        return unitsDtos.ToList();
    }

    public async Task<UnitDto?> GetUnitByIdAsync(int id)
    {
        var unit = await _context.Units.FirstOrDefaultAsync(unit => unit.Id == id);
        
        return unit.ToDto();
    }
}