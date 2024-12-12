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
    public async Task<List<UnitListDto>> GetAllUnitsAsync()
    {
        var units = await _context.Units.ToListAsync();
        
        var unitsDtos = units.Select(unit => unit.ToListDto());
        
        return unitsDtos.ToList();
    }

    public async Task<UnitDetailDto?> GetUnitByIdAsync(int unitId)
    {
        var unit = await _context.Units.Include(entity => entity.Reviews).FirstOrDefaultAsync(unit => unit.Id == unitId);
        
        return unit.ToDetailDto();
    }

    public async Task<bool> UnitExistsAsync(int unitId)
    {
        return await _context.Units.AnyAsync(unit => unit.Id == unitId);
    }
}