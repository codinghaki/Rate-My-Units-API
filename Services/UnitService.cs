using Microsoft.EntityFrameworkCore;
using Rate_My_Units_API.Context;
using Rate_My_Units_API.Dtos.Unit;
using Rate_My_Units_API.Helpers;
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
    public async Task<List<UnitListDto>> GetAllUnitsAsync(UnitQueryObject unitQueryObject)
    {
        var units = _context.Units.AsQueryable();

        if (!string.IsNullOrEmpty(unitQueryObject.Code))
        {
            units = units.Where(x => x.Code.Contains(unitQueryObject.Code));
        }

        int skipNumber = (unitQueryObject.PageNumber - 1) * unitQueryObject.PageSize;
        
        var unitsDtos = await units.Select(unit => unit.ToListDto()).Skip(skipNumber).Take(unitQueryObject.PageSize).ToListAsync();
        
        return unitsDtos;
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