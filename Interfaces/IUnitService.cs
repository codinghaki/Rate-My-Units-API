using Rate_My_Units_API.Dtos.Unit;
using Rate_My_Units_API.Helpers;
using Rate_My_Units_API.Models;

namespace Rate_My_Units_API.Interfaces;

public interface IUnitService
{
    Task<List<UnitListDto>> GetAllUnitsAsync(UnitQueryObject unitQueryObject);
    
    Task<UnitDetailDto?> GetUnitByIdAsync(int unitId);
    
    Task<bool> UnitExistsAsync(int unitId);
}